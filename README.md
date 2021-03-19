# FocalPointDMSClient
GUI client built with WPF to consume the FocalPointDMSWebServer REST API.  Initial project goals are to implement create, read, update, and delete actions
with the server for all entities that will be contained within the database.  The server-client will act as a sort of Dealer Management Solution that is
focused on off-highway equipment.

Screenshot of what the main window currently looks like.
![Screenshot](https://user-images.githubusercontent.com/6564055/111844420-03e7d700-88d1-11eb-922e-3fe2998077e8.png)

The current goal is to have the ability to accururately display every database entity within this screen.  Additional GUI elements will be built that 
focus on managing an individual record or adding new records.

This project is still in the early stage.  Currently, there is read implementations for both customers and equipment.  Current short term goal is to hash out create, update, and delete functionality for these two entities, then expand it to include other entities. 
