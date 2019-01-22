using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        int width = 100;
        int height = 100;
        int promien = 0;


        Rectangle[,] felder;
        DispatcherTimer timer = new DispatcherTimer();

        bool MonteCasino = false;

        
        public MainWindow()
        {
            InitializeComponent();
            
          


            myCanvas.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            myCanvas.Arrange(new Rect(0.0, 0.0, myCanvas.DesiredSize.Width, myCanvas.DesiredSize.Height));

            ObservableCollection<string> reguly = new ObservableCollection<string>();
            reguly.Add("Von Neumann");
            reguly.Add("Moore");
            reguly.Add("Hexagonal left");
            reguly.Add("Hexagonal right");
           
            reguly.Add("Pentagonal up");
            reguly.Add("Pentagonal down");
           
            reguly_box.ItemsSource = reguly;



      
        }
        private Brush PickBrush()
        {
            Brush brush = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256)));
            return brush;

        }
        


        private void Timer_Tick(object sender, EventArgs e)
        {

            int[,] kolor = new int[height, width];
            Brush[,] kolory = new Brush[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int nad = i - 1;

                    int pod = i + 1;

                    int lewo = j - 1;

                    int prawo = j + 1;

                    if (Pbc_checkbox.IsChecked == true)
                    {
                        if (nad < 0) { nad = height - 1; }
                        if (pod >= height) { pod = 0; }
                        if (lewo < 0) { lewo = width - 1; }
                        if (prawo >= width) { prawo = 0; }
                    }
                    if (Pbc_checkbox.IsChecked == false)
                    {
                        if (nad < 0) { nad = 0; }
                        if (pod >= height) { pod = height - 1; }
                        if (lewo < 0) { lewo = 0; }
                        if (prawo >= width) { prawo = width - 1; }
                    }

                    if (MonteCasino != true)
                    {

                        if (reguly_box.Text == "Moore")
                        {
                            kolory[i, j] = felder[i, j].Fill;
                            if (felder[nad, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, lewo].Fill;
                            if (felder[nad, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, j].Fill;
                            if (felder[nad, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, prawo].Fill;
                            if (felder[i, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, lewo].Fill;
                            if (felder[i, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, prawo].Fill;
                            if (felder[pod, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, lewo].Fill;
                            if (felder[pod, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, prawo].Fill;
                            if (felder[pod, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, j].Fill;
                        }
                        if (reguly_box.Text == "Von Neumann")
                        {
                            kolory[i, j] = felder[i, j].Fill;
                            if (felder[nad, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, j].Fill;
                            if (felder[i, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, lewo].Fill;
                            if (felder[i, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, prawo].Fill;
                            if (felder[pod, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, j].Fill;

                        }
                        if (reguly_box.Text == "Hexagonal left")
                        {
                            kolory[i, j] = felder[i, j].Fill;
                            if (felder[nad, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, lewo].Fill;
                            if (felder[nad, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, j].Fill;

                            if (felder[i, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, lewo].Fill;
                            if (felder[i, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, prawo].Fill;

                            if (felder[pod, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, prawo].Fill;
                            if (felder[pod, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, j].Fill;
                        }
                        if (reguly_box.Text == "Hexagonal right")
                        {
                            kolory[i, j] = felder[i, j].Fill;

                            if (felder[nad, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, j].Fill;
                            if (felder[nad, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, prawo].Fill;
                            if (felder[i, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, lewo].Fill;
                            if (felder[i, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, prawo].Fill;
                            if (felder[pod, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, lewo].Fill;

                            if (felder[pod, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, j].Fill;
                        }
                        if (reguly_box.Text == "Pentagonal down")
                        {
                            kolory[i, j] = felder[i, j].Fill;
                            if (felder[nad, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, lewo].Fill;
                            if (felder[nad, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, j].Fill;
                            if (felder[nad, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[nad, prawo].Fill;
                            if (felder[i, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, lewo].Fill;
                            if (felder[i, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, prawo].Fill;

                        }
                        if (reguly_box.Text == "Pentagonal up")
                        {
                            kolory[i, j] = felder[i, j].Fill;

                            if (felder[i, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, lewo].Fill;
                            if (felder[i, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[i, prawo].Fill;
                            if (felder[pod, lewo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, lewo].Fill;
                            if (felder[pod, prawo].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, prawo].Fill;
                            if (felder[pod, j].Fill != Brushes.Cyan)
                                kolory[i, j] = felder[pod, j].Fill;
                        }

                        else { }

                    }
                    else
                    {
                        int tmp = 0;
                        if (reguly_box.Text == "Moore")
                        {
                            kolory[i, j] = felder[i, j].Fill;
                            if (felder[nad, lewo].Fill != felder[i, j].Fill)
                                tmp++;
                            if (felder[nad, j].Fill != felder[i, j].Fill)
                                tmp++;
                            if (felder[nad, prawo].Fill != felder[i, j].Fill)
                                tmp++;
                            if (felder[i, lewo].Fill != felder[i, j].Fill)
                                tmp++;
                            if (felder[i, prawo].Fill != felder[i, j].Fill)
                                tmp++;
                            if (felder[pod, lewo].Fill != felder[i, j].Fill)
                                tmp++;
                            if (felder[pod, j].Fill != felder[i, j].Fill)
                                tmp++;
                            if (felder[pod, prawo].Fill != felder[i, j].Fill)
                                tmp++;
                            if (tmp > 0)
                            {
                                int max;
                                int x,y;
                                max = 0;
                                    x =i;
                                    y=j;
                                 
                                int [,] tab = new int[3,3];
                                 for(int h =0 ; h<3 ; h++){
                                for(int g =0 ; g<3 ; g++){
                                        tab[g,h]= 0;
                                 }  
                                }
                                
                                    
                                    
                                   int temp1= 3;
                                   int  temp2 =3;
                                 if(nad == height -2)
                                    {
                                    temp1--;
                                    }  
                                 else if(nad == height -1)
                                    {
                                    temp1 = temp1 -2;
                                    
                                    }   
                                else if(nad == height )
                                    {
                                    temp1= 0;
                                    }   
                                 else{
                                    temp1= 3;
}
                                 if(lewo == width -2)
                                    {
                                    temp2--;
                                    }   
                                  else if(lewo == width -1)
                                    {
                                    temp2 = temp2 -2;
                                   
                                    }  
                                   else if(lewo == width)
                                    {
                                    temp2= 0;
                                    }  
                                   else 
                                    {
                                    temp2= 3;
                                    }
                                 
                                for( int h =0 ; h<temp2 ; h++){
                                for(int g =0 ; g<temp1 ; g++){
                                    int p = nad+g;
                                    int k = lewo +h;
                                       
                                        if(h==1 && g==1){}
                                        else{
                                       
                                    for(int a =0 ; a<temp2 ;a++){
                                        for(int b =0 ; b<temp1 ; b++){
                                            if(felder[p, k].Fill == felder[nad+b, lewo+a].Fill )
                                            {
                                                    if(a==1 && b==1){
                                                   // if(p!=(nad+b) && k!=(lewo+a)){
                                                 
                                                      //  }
                                                    }
                                                    else{tab[g,h]++;                                                     
                                                               }
                                                    }
                                                       


                                             }
                                        }

                                        }/*
                                    
                                         int [,] tab = new int[3,3];
                                 for(int h =0 ; h<3 ; h++){
                                    if(lewo + h == width){
                                        lewo 
                                            }
                                for(int g =0 ; g<3 ; g++){
                                        tab[g,h]= 0;
                                          if(h==1 && g==1){
                                            }
                                          else{
                            if (felder[nad, lewo].Fill != felder[nad +g, lewo+h].Fill)
                                 tab[g,h]++; 
                            if (felder[nad, j].Fill != felder[nad+g, lewo+h].Fill)
                                 tab[g,h]++; 
                            if (felder[nad, prawo].Fill != felder[nad+g, lewo+h].Fill)
                                 tab[g,h]++; 
                            if (felder[i, lewo].Fill != felder[nad+g, lewo+h].Fill)
                                 tab[g,h]++; 
                            if (felder[i, prawo].Fill != felder[nad+g, lewo+h].Fill)
                                 tab[g,h]++; 
                            if (felder[pod, lewo].Fill != felder[nad+g, lewo+h].Fill)
                                 tab[g,h]++; 
                            if (felder[pod, j].Fill != felder[nad+g, lewo+h].Fill)
                                 tab[g,h]++; 
                            if (felder[pod, prawo].Fill != felder[nad+g, lewo+h].Fill)
                                 tab[g,h]++; 

                                     }
                                     */
                                    if(max < tab[g,h])
                                    {
                                                max = tab[g,h];
                                                x = nad+ g;
                                                y =lewo + h;
                                     }
                                   // else if(max == tab[g,h] ){
                                          // int los_max = random.Next(0,1001) ;
                                          //  if(los_max>500){
                                               // if(kolory[i, j] ==felder[x, y].Fill)
                                               // {
                                              //  max = tab[g,h];
                                              //  x = nad + g;
                                             //  y =lewo + h;
                                             //  }

                                                  

                                  //   }
                                    
                                    }
                                }






                                    

                                kolory[i, j] = felder[x, y].Fill;
                                
                            }
                           
                        }
                       

                        else { 
                                 MessageBoxResult result = MessageBox.Show("Mc tylko dla moora");
                             timer.Stop();
                 myCanvas.Children.Clear();
                                }

                    }

                }
                }
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (felder[i, j].Fill == Brushes.Cyan)
                        {
                            felder[i, j].Fill = kolory[i, j];
                        }
                        else if(MonteCasino == true){
                        felder[i, j].Fill = kolory[i, j];
                    }

                        // else { felder[i, j].Fill = felder[i, j].Fill;  }
                    
                }
            }
        }

        private void R_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)sender).Fill = PickBrush();
              //  (((Rectangle)sender).Fill == Brushes.Cyan) ? Brushes.Red : Brushes.Cyan;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if (reguly_box.Text == "")
            {

                MessageBoxResult result = MessageBox.Show("Wybierz regule!");
            }
            // else if (int.Parse(textbox_x.Text) > 100 || int.Parse(textbox_y.Text) > 100)
            // {
            //    MessageBoxResult result = MessageBox.Show("X lub Y wieksze niz 100");
            // }
           
            if (StartStop.Content != "Wznow!")
            {
                timer.Stop();
                StartStop.Content = "Wznow!";
            }
            else
            {
                timer.Start();
                StartStop.Content = "Stop!";

            }

        }

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

      

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MonteCasino = false;
            int num;
            if (reguly_box.Text == "")
            {

                MessageBoxResult result = MessageBox.Show("Wybierz regule!");
            }
           // else if (int.Parse(textbox_x.Text) > 100 || int.Parse(textbox_y.Text) > 100)
            //{
              //  MessageBoxResult result = MessageBox.Show("X lub Y wieksze niz 100");
            //}
            else if (!textbox_x.Text.Equals(textbox_y.Text))
            {
                MessageBoxResult result = MessageBox.Show("X oraz Y musza byc rowne");
            }
            else if (textbox_zarodki.Text.Equals("0") || textbox_zarodki.Text.Equals("") || !int.TryParse(textbox_zarodki.Text, out num))
            {
                MessageBoxResult result = MessageBox.Show("Za mala lub niepoprawna liczba zarodkow");
            }
            /* else if ((int.Parse(textbox_promien.Text) * int.Parse(textbox_zarodki.Text)) > width)
             {
                 MessageBoxResult result = MessageBox.Show("Zly promien");
             }*/
               else
               {
                   width = int.Parse(textbox_x.Text);
                   height = int.Parse(textbox_y.Text);
                   if (!textbox_promien.Text.Equals("") || !textbox_promien.Text.Equals("0"))
                   {
                       promien = int.Parse(textbox_promien.Text);
                   }


                   felder = new Rectangle[height, width];
                   int liczba_zarodkow = int.Parse(textbox_zarodki.Text);
                   Rectangle r = new Rectangle();
                   for (int i = 0; i < height; i++)
                   {
                       for (int j = 0; j < width; j++)
                       {
                           r = new Rectangle();
                           r.Width = myCanvas.ActualWidth / width - 2.0;
                           r.Height = myCanvas.ActualHeight / height - 2.0;
                           r.Fill = (random.Next(0, 2) == 1) ? Brushes.Cyan : Brushes.Cyan;
                           myCanvas.Children.Add(r);
                           Canvas.SetLeft(r, j * myCanvas.ActualWidth / width);
                           Canvas.SetTop(r, i * myCanvas.ActualHeight / height);
                           r.MouseDown += R_MouseDown;

                           felder[i, j] = r;
                       }
                   }

                   if (textbox_promien.Text.Equals("") || promien == 0)
                   {
                    if (rowno.IsChecked == false){
                       for (int i = 0; i < liczba_zarodkow; i++)
                       {

                           int x_zarodka = random.Next(0, width);
                           int y_zarodka = random.Next(0, height);
                           felder[x_zarodka, y_zarodka].Fill = PickBrush();
                       }
                       }
                    else{
                        int x_zarodka =  ((width/(int)(Math.Sqrt(liczba_zarodkow))))/2 -1;
                           int y_zarodka = ((height/((int)Math.Sqrt(liczba_zarodkow))))/2 -1 ;
                        felder[x_zarodka, y_zarodka].Fill = PickBrush();
                         for (int i = 1; i < liczba_zarodkow; i++){
                            x_zarodka +=  (width/((int)Math.Sqrt(liczba_zarodkow)))-1;
                            
                            if( x_zarodka >= width){
                                x_zarodka = ((width/((int)Math.Sqrt(liczba_zarodkow))))/2 -1 ;
                                  y_zarodka +=(height/((int)Math.Sqrt(liczba_zarodkow)))-1 ;
                                
                                if(y_zarodka >= height){MessageBoxResult result = MessageBox.Show("tyle nie zmieszcze" + i );}
                                }
                                //else if(y_zarodka == height){y_zarodka = height-1;}
                            
                             //else if(x_zarodka == width){x_zarodka = width -1;}

                           felder[x_zarodka, y_zarodka].Fill = PickBrush();


                            }


                    }
                   }
                   else
                   {
                            if(promien > 50 )
                            {
                    MessageBoxResult result = MessageBox.Show("Za duzy promien");
                        }
                            else{
                       int x_zarodka = promien;
                       int y_zarodka = promien;
                    int ilosc = 0;
                    for (int i = 0; i < liczba_zarodkow; i++)
                       {
                        
                        int spr = 0;
                        int licznik = 0;
                        int x, y, z;
                       
                        x = promien;
                        y = width - promien;
                        z = height - promien;
                        do
                        {
                           
                            x_zarodka = random.Next(x,y);
                            y_zarodka = random.Next(x,z );
                            for (int j = (x_zarodka - promien); j <= x_zarodka + promien; j++)
                            {
                                for (int k = (y_zarodka - promien); k <= (y_zarodka +promien); k++)
                                {
                                  
                                    if (felder[j, k].Fill != Brushes.Cyan)
                                    {
                                        //spr++;
                                        if ((int)(Math.Sqrt(((x_zarodka - j) ^ 2) + ((y_zarodka - k) ^ 2))) < promien)
                                            spr++;
                                    }
                                    
                                }
                            }
                            if (spr == 0)
                            {
                                felder[x_zarodka, y_zarodka].Fill = PickBrush();
                                ilosc++;
                            }

                            licznik++;
                            if(z>x+1 )
                            z--;
                          
                            if (y > x+1)
                            y--;
                            
                            if(y==x || z == x)
                            {
                                x ++;
                                y = width - promien;
                                z = height - promien;
                                if (y <= x || z <= x)
                                    x = promien;

                            }

                            if(licznik >= 1000)
                            {
                                 
                             
                                spr = 0;
                                
                            }
                        } while (spr > 0);
                       
                    }
                    MessageBoxResult result = MessageBox.Show("udało mi sie wylosować : " + ilosc + " ziaren o określonych warunkach ");

                }

               }

                timer.Interval = TimeSpan.FromSeconds(1.0);
                       timer.Tick += Timer_Tick;
                       timer.Start();
                      

               
               
                   }
           


        }

        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                 myCanvas.Children.Clear();
                
              
            }
            else
            {

                

            }
        }


      

      

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            MonteCasino = true;
            int num;
            if (reguly_box.Text == "")
            {

                MessageBoxResult result = MessageBox.Show("Wybierz regule!");
            }
           // else if (int.Parse(textbox_x.Text) > 100 || int.Parse(textbox_y.Text) > 100)
            //{
              //  MessageBoxResult result = MessageBox.Show("X lub Y wieksze niz 100");
            //}
            else if (!textbox_x.Text.Equals(textbox_y.Text))
            {
                MessageBoxResult result = MessageBox.Show("X oraz Y musza byc rowne");
            }

            else if (textbox_zarodki.Text.Equals("0") || textbox_zarodki.Text.Equals("") || !int.TryParse(textbox_zarodki.Text, out num))
            {
                MessageBoxResult result = MessageBox.Show("Za mala lub niepoprawna liczba zarodkow");
            }
           

            /* else if ((int.Parse(textbox_promien.Text) * int.Parse(textbox_zarodki.Text)) > width)
             {
                 MessageBoxResult result = MessageBox.Show("Zly promien");
             }*/
               else
               {
                   int ilosc =  int.Parse(ilos_kol.Text);
                
                   width = int.Parse(textbox_x.Text);
                   height = int.Parse(textbox_y.Text);
                   Brush [] tab_kol = new Brush[ilosc];
                    for(int a =0 ; a<ilosc;a++){
                    tab_kol[a] = PickBrush();
                        }



                   felder = new Rectangle[height, width];
                   
                   Rectangle r = new Rectangle();
                   for (int i = 0; i < height; i++)
                   {
                       for (int j = 0; j < width; j++)
                       {
                           r = new Rectangle();
                           r.Width = myCanvas.ActualWidth / width - 2.0;
                           r.Height = myCanvas.ActualHeight / height - 2.0;
                           r.Fill = (random.Next(0, 2) == 1) ? Brushes.Cyan : Brushes.Cyan;
                           myCanvas.Children.Add(r);
                           Canvas.SetLeft(r, j * myCanvas.ActualWidth / width);
                           Canvas.SetTop(r, i * myCanvas.ActualHeight / height);
                           r.MouseDown += R_MouseDown;

                           felder[i, j] = r;
                       }
                   }

                   if (textbox_promien.Text.Equals("") || promien == 0)
                   {
                    
                    int los = 0;
                   for (int j = 0; j < width; j++){
                       for (int i = 0; i < height; i++)
                       {
                            los = random.Next(0, ilosc);
                           
                           felder[i, j].Fill = tab_kol[los];
                       }
                       }
                       }
                   

                  
                   
                   else
                  {
                    MessageBoxResult result = MessageBox.Show("promien musi byc równy 0");

                }

               

                timer.Interval = TimeSpan.FromSeconds(1.0);
                       timer.Tick += Timer_Tick;
                       timer.Start();
                      

               
               
                   }
           


        }






        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
            if(MonteCasino != true){
                MonteCasino = true;
                
                mc_button.Content = "MCT";
            }
            else
            {
                MonteCasino = false;
                mc_button.Content = "MCF";
            }
            timer.Interval = TimeSpan.FromSeconds(1.0);
            timer.Tick += Timer_Tick;
            timer.Start();

        }
    }
}
