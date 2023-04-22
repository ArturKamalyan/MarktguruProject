Hello, here i will provide some details about the project, Please read this file before testing.

For authentication i've created basic authentication handler which will authorize Product CRUD actions
with a hard-coded username and password, please don't forget to add basic auth credentials for those actions
if you are going to test API's with other tools, i will also provide you POSTMAN collection example with all the requests
so you can use that also.

For Get Products list and Get single product details API you can also make requests without providing basic auth params as it is said in the Task.

For Add Product API i've added Fluent Validator, so Name and Price will be validated before doing any actions,
also for taking care duplicate names for Products, i have added a unique name generator which will apply current datetime to name if 
the product name already exists.

For Updating Product i've kept createdDate time as it was created and u can't update it, and also on that action 
is applied same validators as on Add action.

Plese don't forget that for CRUD actions u should provide a basic credentials.

Feel free to contact me if u have any kind of questions before testing.

Regards.



*****Credentials******

Username: superadmin
Password: 12345

**********************
