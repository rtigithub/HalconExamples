import clr
from time import sleep
clr.AddReference('HalconDotNet')
from HalconDotNet import *

HalconWindowHandle = HOperatorSet.OpenWindow(HTuple(0),HTuple(0),HTuple(256),HTuple(256),HTuple(0),HTuple('visible'),HTuple(''))
myImage = HOperatorSet.ReadImage('fabrik')
HOperatorSet.DispImage(myImage, HalconWindowHandle)
myImageSize = HOperatorSet.GetImageSize(myImage)
HOperatorSet.SetPart(HalconWindowHandle, HTuple(0), HTuple(0),myImageSize[1]-1,myImageSize[0]-1)
HOperatorSet.DispImage(myImage, HalconWindowHandle)
sleep(2)
HOperatorSet.CloseWindow(HalconWindowHandle)
