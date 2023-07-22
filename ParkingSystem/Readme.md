## Demo App
``` bash
$ dotnet run

$ create_parking_lot 10
Created a parking lot with 10 slots

$ park a-123-bc hitam mobil
Allocated slot number: 1

$ park b-234-cd merah motor
Allocated slot number: 2

$ park c-345-de hitam motor
Allocated slot number: 3

$ park d-456-ef merah mobil
Allocated slot number: 4

$ park e-133-fg hitam motor
Allocated slot number: 5

$ park f-341-gh putih motor
Allocated slot number: 6

$ park g-289-hi biru mobil
Allocated slot number: 7

$ park h-768-ij hijau mobil
Allocated slot number: 8

$ park i-098-jk silver mobil
Allocated slot number: 9

$ park j-890-kl hitam motor
Allocated slot number: 10

$ slot_numbers_for_vehicles_with_color hitam
1, 3, 5, 10, 

$ slot_number_for_registration_number j-890-kl
10

$ leave 10
Slot number 10 is free

$ slot_number_for_registration_number j-890-kl
Not Found

$ registration_numbers_for_vehicles_with_color hitam
A-123-BC, C-345-DE, E-133-FG

$ registration_numbers_for_vehicles_with_even_plate
B-234-CD, D-456-EF, H-768-IJ, I-098-JK

$ registration_numbers_for_vehicles_with_odd_plate
A-123-BC, C-345-DE, E-133-FG, F-341-GH, G-289-HI

$ type_of_vehicles mobil
Slot Number		Type		Vehicle Number		Color
1		A-123-BC		MOBIL		HITAM
4		D-456-EF		MOBIL		MERAH
7		G-289-HI		MOBIL		BIRU
8		H-768-IJ		MOBIL		HIJAU
9		I-098-JK		MOBIL		SILVER
Total : 5

$ type_of_vehicles motor
Slot Number		Type		Vehicle Number		Color
2		B-234-CD		MOTOR		MERAH
3		C-345-DE		MOTOR		HITAM
5		E-133-FG		MOTOR		HITAM
6		F-341-GH		MOTOR		PUTIH
Total : 4

$ status
Slot Number		Type		Vehicle Number		Color
1		A-123-BC		MOBIL		HITAM
2		B-234-CD		MOTOR		MERAH
3		C-345-DE		MOTOR		HITAM
4		D-456-EF		MOBIL		MERAH
5		E-133-FG		MOTOR		HITAM
6		F-341-GH		MOTOR		PUTIH
7		G-289-HI		MOBIL		BIRU
8		H-768-IJ		MOBIL		HIJAU
9		I-098-JK		MOBIL		SILVER

$ leave 1
Slot number 1 is free

$ status
Slot Number		Type		Vehicle Number		Color
2		B-234-CD		MOTOR		MERAH
3		C-345-DE		MOTOR		HITAM
4		D-456-EF		MOBIL		MERAH
5		E-133-FG		MOTOR		HITAM
6		F-341-GH		MOTOR		PUTIH
7		G-289-HI		MOBIL		BIRU
8		H-768-IJ		MOBIL		HIJAU
9		I-098-JK		MOBIL		SILVER

$ exit
```