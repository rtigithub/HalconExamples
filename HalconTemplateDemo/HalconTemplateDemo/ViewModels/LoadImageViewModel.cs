//-----------------------------------------------------------------------
// <copyright file="LoadProcessViewModel.cs" company="Resolution Technology, Inc.">
//     Copyright (c) Resolution Technology, Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace HalconTemplateDemo.ViewModels
{
     using System;
     using System.Reactive;
     using System.Reactive.Linq;
     using System.Threading.Tasks;
     using HalconDotNet;
     using Models;
     using ReactiveUI;
     using Rti.DisplayUtilities;

     /// <summary>
     /// LoadProcessViewModel class for image load processing.
     /// </summary>
     public class LoadImageViewModel : ProcessViewModelBase<MainViewModel, LoadImageProcessor>
     {
          #region Private Declarations

          #region Interactions

          /// <summary>
          /// Stores the Interaction to get a file name from the user.
          /// </summary>
          private Interaction<Unit, string> getFileName;

          #endregion Interactions

          #region ObservableAsPropertyHelper Fields

          /// <summary>
          /// Stores the image.
          /// </summary>
          private ObservableAsPropertyHelper<HImage> image;

          /// <summary>
          /// Stores the image height.
          /// </summary>
          private ObservableAsPropertyHelper<int> imageHeight;

          /// <summary>
          /// Stores the image width.
          /// </summary>
          private ObservableAsPropertyHelper<int> imageWidth;

          /// <summary>
          /// Stores the ProcessingResult returned from ProcessAsync.ToProperty call.
          /// </summary>
          private ObservableAsPropertyHelper<ProcessingResult> processingResults;

          #endregion ObservableAsPropertyHelper Fields

          /// <summary>
          /// Stores the file name string.
          /// </summary>
          private string fileName = "No File Loaded";

          /// <summary>
          /// Stores a value indicating whether the class has been disposed.
          /// </summary>
          private bool isDisposed = false;

          #endregion Private Declarations

          #region Constructors

          /// <summary>
          /// Initializes a new instance of the LoadProcessViewModel class.
          /// </summary>
          /// <param name="mainVM">A reference to the main view model that owns this class.</param>
          /// <param name="processor">Processor class for this process.</param>
          public LoadImageViewModel(IMainViewModel mainVM, IProcessor processor)
              : base(mainVM, processor)
          {
               this.getFileName = new Interaction<Unit, string>();

               // this.CanExecute = this.WhenAny(x => x.FileName, x => (x.Value != string.Empty) &&
               // (x.Value != null));

               // The Command must be recreated with the new CanExecute observable for it to be used.
               // this.Command = ReactiveCommand.CreateFromTask(_ => this.ProcessAsync(), this.CanExecute);

               // To force immediate disposal of large or Iconic objects, uncomment the Do clause
               // line, otherwise the GarbageCollection will do it after enough memory is used.
               this.Command
                    // .Do(_ => this.ProcessingResults?.Dispose())
                    .ToProperty(this, x => x.ProcessingResults, out this.processingResults);

               // add this and the property and field if it is needed.
               this.Command.IsExecuting
                  .ToProperty(this, x => x.IsLoading, out this.isLoading);

               this.DisposeCollection.Add(this.WhenAny(x => x.Processor.Image, x => x.Value)
                   .Where(x => x != null)
                   .Where(x => x.IsInitialized())
                   .Do(_ => this.Image?.Dispose())
                   .ToProperty(this, x => x.Image, out this.image));

               this.DisposeCollection.Add(
                   this.WhenAnyValue(x => x.Processor.DebugDisplay)
                   .Where(x => x.DisplayList.Count > 0)
                   .SubscribeOn(RxApp.TaskpoolScheduler)
                   .Subscribe(x =>
                   {
                        this.DebugDisplay.Dispose();
                        this.DebugDisplay = x;
                   }));

               this.DisposeCollection.Add(this.WhenAny(x => x.Processor.Image, x => x.Value)
                   .Where(x => x != null)
                   .Where(x => x.IsInitialized())
                   .SubscribeOn(RxApp.TaskpoolScheduler)
                   .Subscribe(x =>
                   {
                        this.SetDisplay();
                        this.MainViewModelRef.AppState = 0;
                   }));

               this.DisposeCollection.Add(this.WhenAnyValue(x => x.Processor.ImageHeight)
                   .StartWith(0)
                   .ToProperty(this, x => x.ImageHeight, out this.imageHeight));

               this.DisposeCollection.Add(this.WhenAnyValue(x => x.Processor.ImageWidth)
                   .StartWith(0)
                   .ToProperty(this, x => x.ImageWidth, out this.imageWidth));
          }

          #endregion Constructors

          #region Public Properties

          #region Interactions

          /// <summary>
          /// Gets the getFileName Interaction.
          /// </summary>
          public Interaction<Unit, string> GetFileName => this.getFileName;

          #endregion Interactions

          #region Commands

          #endregion Commands

          #region ProcessingResult Properties

          /// <summary>
          /// Gets the processing results.
          /// </summary>
          public ProcessingResult ProcessingResults => this.processingResults.Value;

          #endregion ProcessingResult Properties

          #region Observable Properties

          #endregion Observable Properties

          /// <summary>
          /// Gets or sets the file name.
          /// </summary>
          public string FileName
          {
               get => this.fileName;

               set => this.RaiseAndSetIfChanged(ref this.fileName, value);
          }

          /// <summary>
          /// Gets the image.
          /// </summary>
          public HImage Image => this.image.Value;

          /// <summary>
          /// Gets the image height.
          /// </summary>
          public int ImageHeight => this.imageHeight.Value;

          /// <summary>
          /// Gets the image width.
          /// </summary>
          public int ImageWidth => this.imageWidth.Value;

          #endregion Public Properties

          #region Protected Methods

          /// <summary>
          /// Builds a DisplayCollection.
          /// </summary>
          /// <returns>the DisplayCollection.</returns>
          protected override DisplayCollection BuildDisplayItem()
          {
               DisplayCollection tempDC = new DisplayCollection()
               {
                    ClearDisplayFirst = true
               };

               tempDC.AddDisplayObject(this.Processor.Image.CopyObj(1, -1));

               return tempDC;
          }

          /// <summary>
          /// Overrides the Dispose method of IDisposable that actually disposes of managed resources.
          /// </summary>
          /// <param name="disposing">A boolean value indicating whether the class is being disposed.</param>
          protected override void Dispose(bool disposing)
          {
               if (!this.isDisposed)
               {
                    if (disposing)
                    {
                         //// Dispose of managed resources here.
                    }

                    //// Dispose of unmanaged resources here.

                    this.Image?.Dispose();

                    this.isDisposed = true;
               }

               // Call base.Dispose, passing parameter.
               base.Dispose(disposing);
          }

          /// <summary>
          /// Implements the asynchronous method for this process.
          /// </summary>
          /// <returns>A Task result containing a ProcessingResult.</returns>
          protected override async Task<ProcessingResult> ProcessAsync()
          {
               try
               {
                    this.FileName = await this.GetFileName.Handle(new Unit());

                    if (this.FileName != string.Empty)
                    {
                         Tuple<string> parameters = new Tuple<string>(this.FileName);
                         return await Task.Factory.StartNew(() => this.Processor.Process(parameters));
                    }
                    else
                    {
                         return new ProcessingResult();
                    }
               }
               catch (Exception)
               {
                    ProcessingResult result = new ProcessingResult()
                    {
                         ErrorMessage = "The Interaction to handle getting the file name is not registered."
                    };

                    return result;
               }
          }

          #endregion Protected Methods

          #region Private Methods

          #endregion Private Methods
     }
}