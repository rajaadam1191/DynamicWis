function validate_registration()
{
if(!validate_username())return false
if(!validate_password())return false
if(!validate_retype())return false
if(!validate_role())return false
}
function validate_username()
{
    var useraname=$("input[id$='txt_username']").val();
    if(useraname=="" || useraname==null)
    {
        $("div[id$='div_errorr']").show();
        $("span[id$='spnerror']").text('Please Enter UserName');
        $("input[id$='txt_username']").focus();
 return false;
 }
 else
 {
  $("div[id$='div_errorr']").hide();       
  return true;
  }
}
function validate_password()
{
    var pass=$("input[id$='txt_password']").val();
    if(pass=="" || pass==null)
    {
        //$("input[id$='txt_password']").addClass( "errormsg" );
//        $("input[id$='txt_password']").focus();

$("div[id$='div_errorr']").show();
        $("span[id$='spnerror']").text('Please Enter Password');
       // $("input[id$='txt_password']").focus();
      return false;
    }
    else
    {
        if(pass.length >=6)
        {
            $("input[id$='txt_password']").removeClass( "errormsg" );
            $("span[id$='sp_error']").hide();
            return true;
        }
        else
        {
           $("span[id$='sp_error']").text('Password Length Should be above 6');
          // $("input[id$='txt_password']").focus();
           $("span[id$='sp_error']").show();
            return false;
        }
    }
}
function validate_retype()
{
    var pass=$("input[id$='txt_password']").val();
    var repass=$("input[id$='txt_retype']").val();
    if(repass=="" || repass==null)
    {
       // $("input[id$='txt_retype']").addClass( "errormsg" );
       $("div[id$='div_errorr']").show();
        $("span[id$='spnerror']").text('Please Re-Type Password');
        return false;
    }
    else
    {
        if(repass.length >=6)
        {
           if(repass== pass)
           {
                  $("span[id$='spnretype']").text('Password Can not be matching');
                  $("input[id$='txt_retype']").removeClass( "errormsg" );
                  $("span[id$='spnretype']").hide();
                  return true;
           }
           else
           {
             $("span[id$='spnretype']").text('Password Can not be matching');
              $("input[id$='spnretype']").addClass( "errormsg" );
           // $("input[id$='txt_retype']").focus();
            $("span[id$='spnretype']").show();
            return false;
           }
        }
        else
        {
           $("span[id$='spnretype']").text('Password Length Should be above 6');
            $("input[id$='spnretype']").addClass( "errormsg" );
           //$("input[id$='txt_retype']").focus();
           $("span[id$='spnretype']").show();
            return false;
        }
    }
}
function validate_role()
{
    var role=$("select[id$='ddl_role']").val();
    if(role=="0" || role==null)
    {
      $("div[id$='div_errorr']").show();
        $("span[id$='spnerror']").text('Please Select Role');
        $("select[id$='ddl_role']").focus();
 return false;
 }
 else
 {
  $("div[id$='div_errorr']").hide();       
  return  true;
  }
}