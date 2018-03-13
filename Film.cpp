#include <iostream>
#include<bits/stdc++.h>
using namespace std;

vector <string> movieFestival;
void ucitavanje(float **FILM, int n)
{
   int nGodina, brojFilmova, godOdrz, j;
   
   for (int i = 0; i < n; i++) {
   	  cout << "Gdje se odrzava ovaj festival?  ";
   	  string tempFest;
   	  cin >> tempFest;
   	  movieFestival.push_back(tempFest);
      brojFilmova = 0;
      cout << "Koliko se godina održava ovaj festival (" << i + 1 << "): ";
      cin >> nGodina;
      //nGodina *= 2;
      FILM[i] = new float[(nGodina*2) + 3];
      FILM[i][0] = nGodina;
      for (j = 1; j <= nGodina*2; j=j+2)
      {		
      	 cout << "Unesi godinu odrzavanja: ";
      	 cin >> FILM[i][j];
         cout << "Unesi broj prikazanih filmova "<< FILM[i][j] << " godine: ";
         cin >> FILM[i][j+1];
         brojFilmova += FILM[i][j+1];
      }
      nGodina *=2;
      FILM[i][nGodina+1] = brojFilmova;
      FILM[i][nGodina + 2] = (float)brojFilmova*2 / nGodina;
   }

}
void ispis(float **FILM, int n){
cout << "FILM = ";
   for (int i = 0; i<n; i++){
	  cout << movieFestival[i]<<": ";
	  int nGodina = FILM[i][0]*2;
	  float temptemp = FILM[i][nGodina + 2];
      for (int j = 1; j < FILM[i][0]*2+1; j++){
      	if (j%2 > 0) {
		  cout << "<";
		  } else cout << ", ";
         cout << FILM[i][j];
         	if (j%2 > 0) {
		  cout << "";
		  } else cout << ">";
      }
      cout <<"; Avg="<< temptemp<<";\n";
   }
}
void dealokacija(float **FILM, int n){
   for (int i = 0; i<n; i++){
      delete[] FILM[i];
   }
   delete[] FILM;
   FILM = NULL;
}


int main(){
   int n = 0;
   cout << "Unesite broj filmskih festivala: ";
   cin >> n;
   float** FILM = new float*[n];
   ucitavanje(FILM, n);
   ispis(FILM, n);
   dealokacija(FILM, n);
   return 0;
}
