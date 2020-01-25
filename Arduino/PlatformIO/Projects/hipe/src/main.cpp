#include <Arduino.h>

#include <LiquidCrystal.h>  // Лобавляем необходимую библиотеку
LiquidCrystal lcd(7, 6, 5, 4, 3, 2); // (RS, E, DB4, DB5, DB6, DB7)

void setup(){ 
  lcd.begin(16, 2);                  // Задаем размерность экрана
  
  lcd.setCursor(0, 0);              // Устанавливаем курсор в начало 1 строки
        // Выводим текст
  lcd.setCursor(0, 1);              // Устанавливаем курсор в начало 2 строки
  lcd.print("zelectro.cc");         // Выводим текст
}
int k=0;
void loop()
{ 
lcd.clear();
lcd.setCursor(0, 0);
lcd.print("Hel    lo,Pavel!");
lcd.setCursor(0, 1);
lcd.print(k++);
delay(1000);
}

