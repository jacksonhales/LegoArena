Find Homebase – R&B

0.1. Check distance to wall. 
0.2. If too far close distance until within safe limit, if already safe distance ignore step.
0.3. Check Colour, store colour, rotate right 45 degrees until can’t see colour, then move forward, if only one colour is found twice repeat previous step.
1. If colour red & blue beep to show success. ****

2.1. If red and black detected, turn left 90 degrees from red or 180 degrees from black.
2.2. Travel until you reach the other wall.
2.3. Check if wall is blue, if blue, continue, if not, restart.
2.4. Turn 90 degrees right, check distance, if close enough check colour, if not, close distance before checking colour.
2.5. Turn 90 degrees left, check distance, if close enough check colour, if not, turn right 20 degrees before closing distance and then checking colour.
2.6. Repeat step 2.4 & 2.5 until it can detect red and blue, beep to show success. ****

3. If Blue and yellow are detected, do 2.1 to 2.6 in reverse.

4.1. If Yellow and Black detected, if facing black turn 90 degrees Left or if facing yellow turn 180 degrees left, before heading to wall
4.2. Then do from step 2.3


Command Findwall

Set Passed = false
For
Colour1 = ColourSensor 
For
		Rotate right 45 Degrees
While Colour1 == ColourSensor

Command FindWall
Colour2 = ColourSensor

If Colour1 != Colour2
	Set Passed = true

While Passed == false

Set FoundBase = false

If Colour1 == Red && Colour2 == Blue | Colour1 == Blue && Colour2 == Red
	Set FoundBase = true


Else If Colour1 == Red && Colour2 == Black | Colour2 == Red && Colour1 == Black
	If Colour1 == Red
		Rotate 180 degrees Left
	Else If Colour1 == Black
		Rotate 90 degrees Left
	Command Findwall

	For
		If ColourSensor == Blue
			Colour1 = blue
			Rotate right 90 degrees
			Command FindWall
		If ColourSensor == Red
			Colour2 = red
			Rotate left 90 degrees
			Command FindWall
	While Colour1 != blue && Colour2 != Red
	Set FoundBase = true

Else If Colour1 == Blue && Colour2 == Yellow | Colour2 == Blue && Colour1 == Yellow
	If Colour1 == Blue
		Rotate 180 degrees Right
	Else If Colour1 == Yellow
		Rotate 90 degrees Right
	Command Findwall

	For
		If ColourSensor == Red
			Colour1 = Red
			Rotate Left 90 degrees
			Command FindWall
		If ColourSensor == Blue
			Colour2 = Blue
			Rotate Right 90 degrees
			Command FindWall
	While Colour1 != Red && Colour2 != Blue
	Set FoundBase = true
	
Else If Colour1 == Black && Colour2 == Yellow | Colour2 == Black && Colour1 == Yellow
	If Colour1 == Black
		Rotate 180 degrees Left
	Else If Colour1 == Yellow
		Rotate 90 degrees Left
	Command FindWall
	Rotate 90 Degrees Left
	For
		If ColourSensor == Blue
			Colour1 = blue
			Rotate right 90 degrees
			Command FindWall
		If ColourSensor == Red
			Colour2 = red
			Rotate left 90 degrees
			Command FindWall
	While Colour1 != blue && Colour2 != Red
	Set FoundBase = true
	


Find White block

1. Create range having the minimum as a stored variable that starts at zero, and having the maximum as the highest distance of distance sensor.
2. Store the number of the distance senor into the minimum range, minus a bit.
3. Rotate tiny bit to the right.
4. Repeat steps 2 & 3 until range breaks.
5. Head towards break until distance is close, and then check colour.
6. If white, success, if not, start from 2
