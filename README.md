# DNNContactForm

## Bootstrap Contact Form Module for DNN in C&#35;

This is a Visual Studio project based on a Chris Hammond DNN template for version 7 and above.

To get up and running quickly just build the solution in release mode and install the module using the .zip file created in the `/install` folder.

Once you have added the module to a page you must then go into the module settings and find the module specific settings for the DNNContactForm module. In there you can set a Google Recaptcha code, the recipient email
address for the enquiries and a success page that you want the user directed to on successful submission e.g. `/Success`.  If you leave the success page
blank the module will hide the form and show a success message on submit.

<strong><em>Note:</em></strong> A [Google Recaptcha](https://developers.google.com/recaptcha/) code is required otherwise the form will not submit.

### Module settings

![contact module settings](images/settings.jpg)

### Resources

Check the resources file `/App_localResources/View.ascx.resx` to edit some of the messages.

### Styling 

This module is Bootstrap enabled so if your site is using Bootstrap it should render as a Bootstrap form.

### Validation

Validation is handled by the browser but I am using [custom input validation error messages](https://libraries.io/npm/civem) to improve this.
Some further validation is carried out by the server side code before submission.

Enquiries are logged to a table called <strong>ContactUsFormLog</strong>. 

I am using [Simple.Data](https://github.com/markrendle/Simple.Data) to do the INSERT.  
Note, I am not using object qualifiers in this project. You may need to edit the code
in DatabaseClass.cs for your needs.
