import wpf
from System.Windows import Application

class MyWindow(Window):
    def __init__(self):
        wpf.LoadComponent(self, 'HalconIronPythonWpf.xaml')

MyWindow()
