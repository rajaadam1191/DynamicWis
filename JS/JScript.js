function ConfirmationBox(username) {

var result = confirm('Are you sure you want to delete '+username+' Details?' );
if (result) {

return true;
}
else {
return false;
}
}