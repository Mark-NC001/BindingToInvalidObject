# BindingToInvalidObject
Click "Create Person"
This creates a PersonViewModel and passes it to a new PersonPage.
PersonPage is then bound to the PersonViewModel object.
By clicking the Delete toolbar item, the PersonViewModel gets flagged as deleted.
Navigation.PopModalAsync gets called and then the page should close.
But in fact during the PopModalAsync, it ends up calling bound properties on the PersonViewModel object!
