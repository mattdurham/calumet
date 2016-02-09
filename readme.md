# calumet

Calumet is a class project intended to go through the steps of learning how to use webapig, angularjs and sqlite for the Wednesday Code Louisville .net class of 2016.

## Description

Provide a simple calendar application that will allow users to try to organize good times for shared events. Users will create a calendar, include recipients and then each recipient will be emailed the link to use. Users will then mark off the dates they are available; the software will find where they intersect. 

## Technologies

* Web Api
* Dapper
* sqlite
* AngularJS Material

## Phase 1 2016.02.08

Create Database

1. Events
	* e_id int primary key
	* e_startdate date
	* e_enddate date
	* e_name text
	* e_creator text
	* e_dateortime text
1.  EventRecipients
	* er_id int primary key
	* er_email text
	* er_responded bit
	* er_eid int fk to **Events**
1. EventRecipientDates
	* erd_id int primary key
	* erd_erid int fk to **EventRecipients**
	* erd_startdate date
	* erd_enddate date

