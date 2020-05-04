Imports Neodynamic.SDK.Printing

Public Class Barcode
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Define a ThermalLabel object and set unit to inch and label size
        Dim tLabel As New ThermalLabel(UnitType.Inch, 3, 2)
        tLabel.GapLength = 0.2

        'Define a TextItem object 
        Dim txt As New TextItem(0.1, 0.1, 2.8, 0.5, "MDL-001/X")
        'set Mask info...
        txt.Mask = "%%%%ddd%%"
        txt.MaskIncrement = "1%%"
        'set font
        txt.Font.Name = Neodynamic.SDK.Printing.Font.NativePrinterFontA
        txt.Font.Unit = FontUnit.Point
        txt.Font.Size = 10

        'Define a BarcodeItem object
        Dim bc As New BarcodeItem(0.1, 0.57, 2.8, 1.3, BarcodeSymbology.Code128, "PRD000-A")
        'set Mask info...
        bc.Mask = "%%%d%%%A"
        bc.MaskIncrement = "1%%%B"
        'set barcode size
        bc.BarWidth = 0.02
        bc.BarHeight = 0.75
        'set barcode alignment
        bc.BarcodeAlignment = BarcodeAlignment.MiddleCenter
        'set font
        bc.Font.Name = Neodynamic.SDK.Printing.Font.NativePrinterFontA
        bc.Font.Unit = FontUnit.Point
        bc.Font.Size = 10

        'Add items to ThermalLabel object...
        tLabel.Items.Add(txt)
        tLabel.Items.Add(bc)

        'Create a WindowsPrintJob object
        Using pj As New WindowsPrintJob()
            'Create PrinterSettings object
            Dim myPrinter As New PrinterSettings()
            myPrinter.Communication.CommunicationType = CommunicationType.USB
            myPrinter.Dpi = 203
            myPrinter.ProgrammingLanguage = ProgrammingLanguage.ZPL
            myPrinter.PrinterName = "Zebra  TLP2844-Z"

            'Set PrinterSettings to PrintJob
            pj.PrinterSettings = myPrinter
            'Set num of labels to generate
            pj.Copies = 10
            'Print ThermalLabel object...
            pj.Print(tLabel)
        End Using
    End Sub
End Class