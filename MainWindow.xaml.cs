
using System.Windows;

namespace Wpf_DelegatesVerstehen_2024_02_22;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private delegate bool SelectedMethod(int i);
    
    private int[]? _numbers;

    public MainWindow()
    {
        InitializeComponent();
    }

    #region Hilfsmethode StringToIntArray

    private void StringToIntArray()
    {
        string[] singleValues = TxtInput.Text.Split(',');
        List<int> intValues = new List<int>();
        
        foreach (var singleValue in singleValues)
        {
            if (int.TryParse(singleValue, out int result))
            {
                intValues.Add(result);
            }
        }

        _numbers = intValues.ToArray();
    }

    #endregion

    #region Gerade Zahlen mit benannter Methode

    private void BtnEvenNumbers_OnClick(object sender, RoutedEventArgs e)
    {
        FilterForAll(GeradeZahl);
    }

    #endregion

    #region Zahlen zwischen 13 und 77

    private void BtnBetween13And77_OnClick(object sender, RoutedEventArgs e)
    {
        FilterForAll(Between13And77);
    }

    #endregion
    
    #region Zahlen größer als 10
    
    private void BtnGreaterThan10_OnClick(object sender, RoutedEventArgs e)
    {
        FilterForAll(GroesserAlsZehn);
    }
    
    #endregion

    #region FilterDelegates
    
    // benannte Methode
    bool GeradeZahl(int i)
    {
        return i % 2 == 0;
    }
    
    // benannte Methode
    public bool Between13And77(int i)
    {
        return i > 13 && i < 77;
    }

    // benannte Methode
    bool GroesserAlsZehn(int i)
    {
        return i > 10;
    }

    #endregion
    
    private List<int> FilterDelegate(int[] intArr, SelectedMethod method)
    {
        List<int> intValues = new List<int>();

        for (int i = 0; i < intArr.Length; i++)
        {
            if (method(intArr[i]))
            {
                intValues.Add(intArr[i]);
            }
        }
        return intValues;
    }
    
    private void FilterForAll(SelectedMethod method)
    {
        if (TxtInput.Text.Length == 0) return;
        StringToIntArray();
        TxtOutput.Text = "";
        
        List<int> filtered = FilterDelegate(_numbers!, method);

        TxtOutput.Text = string.Join(",", filtered);
    }
}