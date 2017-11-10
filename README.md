# LegoArena

Logic

Find Homebase R&B

0.1. Check distance to wall. 
0.2. If too far close distance until within safe limit, if already safe distance ignore step.
0.3. Rotate 90 degrees right until next closest wall is found, then close distance.
0.4. Rotate 90 degrees right until it can detect two colours, if only one colour is found twice turn 45 degrees right before repeating previous step.
1. If colour red & blue beep to show success. ****

2.1. If red and black detected, turn right 90 degrees from red or 180 degrees from black.
2.2. Travel until you reach the other wall.
2.3. Check if wall is blue, if blue, continue, if not, restart.
2.4. Turn 90 degrees right, check distance, if close enough check colour, if not, close distance before checking colour.
2.5. Turn 90 degrees left, check distance, if close enough check colour, if not, turn right 20 degrees before closing distance and then checking colour.
2.6. Repeat step 2.4 & 2.5 until it can detect red and blue, beep to show success. ****

3. If Blue and yellow are detected, do 2.1 to 2.6 in reverse.

4.1. If Yellow and Black detected, turn 90 degrees right until it can no longer detect colours.
4.2. Move forward until a wall is detected, check colour
4.3. If red, turn 90 degrees left, if blue, turn 90 degrees right.
4.4. Restart from 0.1



Find White block

1. Create range having the minimum as a stored variable that starts at zero, and having the maximum as the highest distance of distance sensor.
2. Store the number of the distance senor into the minimum range, minus a bit.
3. Rotate tiny bit to the right.
4. Repeat steps 2 & 3 until range breaks.
5. Head towards break until distance is close, and then  check colour.
6. If white, success, if not, start from 2
