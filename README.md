# SimbukaCycle


Question 1
Create an object oriented solution for the following problem:
 Create an API for a Bicycle, to make it cycle. Additionally it must be possible to increase and
decrease the bicycle’s gear.
 Use the Bicycle.php class given in Appendix A. Fill in its methods.
 Feel free to create additional code: classes, properties, constants, methods and constructors
if you feel that is necessary.
 Can you provide automated tests for your code?
Additional information:
- The bicycle’s moving distance after one wheel rotation is denoted as “[Rear wheel
circumference] * [Gear ratio]”.
- The gear ratio is denoted as “[Number of chain ring teeth] / [Number of sprocket teeth]”.
 The chain ring is the cog wheel in the middle of the bike between the pedals.
 The sprocket wheels are attached to the middle of the rear wheel. When a bicycle
switches gears, the chain moves to a different sprocket wheel.
- Take into account that it should be possible to create bicycles with different gear equipment:
 Cheap gear, with
 7 gear levels
 Number of sprocket teeth: 30 – 2 * $gear_level
 Expensive gear, with
 30 gear levels
 Number of sprocket teeth: 46 – floor(1.2 * $gear_level)

- Take into account that it should be possible to create bicycles with several different wheel
sizes. Examples of such wheel sizes are:
 20 inch
 24 inch
 28 inch



Question 2a
Design a database structure which holds the following information. Please make sure to take into
account the rules of database normalization.
- Persons must be stored.
- Cars must be stored.
- A person has a first name and a last name. Together these identify the person.
- A car has a license plate.
- Some persons own cars.
- Persons may even own multiple cars.
- There are different types of cars: sedans and trucks.

Question 2b
Create another database structure, that continues on the structure provided by question 2a. The
following information must be added:
- A car has a brand. Examples: ‘Toyota’, ‘Opel’.
- A car has a brand type. Examples: ‘Corolla’, ‘Corsa’.
- Truck brand types must store a loading capacity.
- Sedan brand types must store the passenger capacity.



Appendix A

<?php
class Bicycle {
/**
* Increases the gear level with 1.
*/
public function increaseGear(): void {
}
/**
* Decreases the gear level with 1.
*/
public function decreaseGear(): void {
}
/**
* Returns the length traveled in meters
*/
public function cycle(int $number_of_rotations): float {
}
}
