
function SelectRedirect()
{
switch(document.getElementById('DropType').value)
{
case "SPC Chart":
window.location="../Reports/ViewQChart.aspx";
break;

//case "Efficiency":
//window.location="../Reports/EfficiencyReports.aspx";
//break;

//case "QC":
//window.location="../Reports/OEERptFrm.aspx";
//break;


/// Can be extended to other different selections of SubCategory //////
default:
window.location="../"; // if no selection matches then redirected to home page
break;
}// end of switch 
}

