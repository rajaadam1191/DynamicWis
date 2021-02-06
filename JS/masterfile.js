
function checksave1()
{
    if(!validate_partno_cyc()) return false 
    if(!validate_optn_cyc()) return false
    if(!validate_cycl()) return false
  
 }   
  
 function validate_partno_cyc()
 {
  var partno=$("select[id$='DropPart_cyc']").val();
 if(partno==null || partno=="-Select-" || partno=="")
 {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Part No');
        $("select[id$='DropPart_cyc']").focus();
 return false;
 }
 else
 {
  $("div[id$='diverror']").hide();       
  return true;
  }
 }
  function validate_optn_cyc()
 {
   var optn=$("select[id$='Dropprocess_cyc']").val();
 if(optn==null|| optn=="-Select-" || optn=="")
 {
  $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Operation');
        $("select[id$='Dropprocess_cyc']").focus();

 return false;
 }
 else
 {
   $("div[id$='diverror']").hide();       
  return true;
  }
 } 

 function  validate_cycl()
 {
        var dept=$("input[id$='Text_cycle']").val();

        if(dept==null|| dept=="")
        {
            $("div[id$='diverror']").show();
            $("span[id$='spn_error']").text('Please Enter Cycle time');
            $("input[id$='Text_cycle']").focus();
            return false;
        }
        else
        {
            $("div[id$='diverror']").hide();       
            return true;
        }
 } 
 
function Labor_validate()
{
if(!validate_rptunit_LE()) return false 
 if(!validate_rptmachine_LE())return false 
 if(!checkdate())return false
 if(!validate_eshift()) return false 
 if(!validate_actual()) return false 
}
function validate_rptunit_LE()
{
  var mach=$("select[id$='ddl_unit_LBeff']").val();
 if(mach==null || mach=="0"|| mach=="-Select-")
 {
  $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select unit');
        $("select[id$='ddl_unit']").focus()
  
     return false;
 }
 else
 {
   $("div[id$='diverror']").hide();
      return true;
  }
}
function validate_rptmachine_LE()
 {

 var machn=$("select[id$='Slct_machine_eff_LE']").val();
 if(machn==null||machn=="0"||machn=="-Select-")
 {
      $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Machine');
        $("select[id$='Slct_machine_rpt']").focus()
     return false;
 }
 else
 {
 $("div[id$='diverror']").hide();
      return true;
  }
 }
function checkdate()
{

  var dt=$("input[id$='txt_date']").val();
 
    if(dt=="" || dt==null)
    {
    $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Date');
        $("input[id$='txt_date']").focus();
       
       return false;
 }
 else
 {
      $("div[id$='diverror']").hide();
      return true;
  }
}
function validate_eshift()
{
  var shift=$("select[id$='ddl_shift']").val();
 
 if(shift==null || shift=="0"|| shift=="-Select-")
 {
   $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Shift');
        $("select[id$='ddl_shift']").focus();
   
     return false;
 }
 else
 {
       $("div[id$='diverror']").hide();

      return true;
  }
}
function  validate_actual()
 {
  var actual=$("input[id$='Text_actual']").val();

 if(actual==null|| actual=="")
 {
  $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Enter Actual time');
        $("input[id$='Text_actual']").focus();
     return false;
 }
 else
 {
       $("div[id$='diverror']").hide();
      return true;
  }
 }
 
 function paretoview_validate()
{
if(!validate_rptunit()) return false 
 if(!validate_rptmachine())return false 
 if(!validate_indicator()) return false 
 if(!validate_shift_perato()) return false 
// if(!checkfrmdatepareto_view())return false
// if(!checkttodatepareto_view())return false
}
function validate_rptunit()
{
  var mach=$("select[id$='ddl_unit_eff']").val();
 if(mach==null || mach=="0"|| mach=="-Select-")
 {
  $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select unit');
        $("select[id$='ddl_unit_eff']").focus()
  
     return false;
 }
 else
 {
   $("div[id$='diverror']").hide();
      return true;
  }
}
function validate_rptmachine()
 {

 var machn=$("select[id$='Slct_machine_eff']").val();
 if(machn==null||machn=="0"||machn=="-Select-")
 {
      $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Machine');
        $("select[id$='Slct_machine_eff']").focus()
     return false;
 }
 else
 {
 $("div[id$='diverror']").hide();
      return true;
  }
 }
function validate_indicator()
{
 var indicator=$("select[id$='ddl_indicator']").val();
 
 if(indicator==null || indicator=="0"|| indicator=="")
 {
  $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Type Of Indicator');
        $("input[id$='ddl_indicator']").focus();
   
     return false;
 }
 else
 {
       $("div[id$='diverror']").hide();
      return true;
  }
}
function validate_shift_perato()
{
 var pshift=$("select[id$='ddl_shiftchart']").val();
 
 if(pshift==null || pshift=="0"|| pshift=="")
 {
 $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Shift');
        $("input[id$='ddl_shiftchart']").focus();
     
     return false;
 }
 else
 {
       $("div[id$='diverror']").hide();
      return true;
  }
}

//function checkfrmdatepareto_view()
//{

//  var dt=$("input[id$='txt_fromdate_chart']").val();
// 
//    if(dt=="" || dt==null)
//    {
//     $("div[id$='diverror']").show();
//        $("span[id$='spn_error']").text('Please Select From Date');
//        $("input[id$='txt_fromdate_chart']").focus();
//       
//       return false;
// }
// else
// {
//       $("div[id$='diverror']").hide();
//      return true;
//  }
//}
//function checkttodatepareto_view()
//{

//  var dt=$("input[id$='txt_todate_chart']").val();
// 
//    if(dt=="" || dt==null)
//    {
//     $("div[id$='diverror']").show();
//        $("span[id$='spn_error']").text('Please Select To Date');
//        $("input[id$='txt_todate_chart']").focus();
//      
//       return false;
// }
// else
// {
//       $("div[id$='diverror']").hide();
//      return true;
//  }
//}

 
 function cycle_validate()
{
 if(!validatetime()) return false 

}
function  validatetime()
{

  var strval =document.getElementById("Text_cycle").value;
 
  var strval1;
    
  //minimum lenght is 6. example 1:2 AM
  if(strval.length < 6)
  {
   alert("Invalid time. Time format should be HH:MM AM/PM.");
   return false;
  }
  
  //Maximum length is 8. example 10:45 AM
  if(strval.lenght > 8)
  {
   alert("invalid time. Time format should be HH:MM AM/PM.");
   return false;
  }
  
  //Removing all space
  strval = trimAllSpace(strval); 
  
  //Checking AM/PM
  if(strval.charAt(strval.length - 1) != "M" && strval.charAt(
      strval.length - 1) != "m")
  {
   alert("Invalid time. Time shoule be end with AM or PM.");
   return false;
   
  }
  else if(strval.charAt(strval.length - 2) != 'A' && strval.charAt(
      strval.length - 2) != 'a' && strval.charAt(
      strval.length - 2) != 'p' && strval.charAt(strval.length - 2) != 'P')
  {
   alert("Invalid time. Time shoule be end with AM or PM.");
   return false;
   
  }
  
  //Give one space before AM/PM
  
  strval1 =  strval.substring(0,strval.length - 2);
  strval1 = strval1 + ' ' + strval.substring(strval.length - 2,strval.length)
  
  strval = strval1;
      
  var pos1 = strval.indexOf(':');
  document.Form1.TextBox1.value = strval;
  
  if(pos1 < 0 )
  {
   alert("invlalid time. A color(:) is missing between hour and minute.");
   return false;
  }
  else if(pos1 > 2 || pos1 < 1)
  {
   alert("invalid time. Time format should be HH:MM AM/PM.");
   return false;
  }
  
  //Checking hours
  var horval =  trimString(strval.substring(0,pos1));
   
  if(horval == -100)
  {
   alert("Invalid time. Hour should contain only integer value (0-11).");
   return false;
  }
      
  if(horval > 12)
  {
   alert("invalid time. Hour can not be greater that 12.");
   return false;
  }
  else if(horval < 0)
  {
   alert("Invalid time. Hour can not be hours less than 0.");
   return false;
  }
  //Completes checking hours.
  
  //Checking minutes.
  var minval =  trimString(strval.substring(pos1+1,pos1 + 3));
  
  if(minval == -100)
  {
   alert("Invalid time. Minute should have only integer value (0-59).");
   return false;
  }
    
  if(minval > 59)
  {
     alert("Invalid time. Minute can not be more than 59.");
     return false;
  }   
  else if(minval < 0)
  {
   alert("Invalid time. Minute can not be less than 0.");
   return false;
  }
   
  //Checking minutes completed.
  
  //Checking one space after the mintues 
  minpos = pos1 + minval.length + 1;
  if(strval.charAt(minpos) != ' ')
  {
   alert("Invalid time. Space missing after minute.Time should have HH:MM AM/PM format.");
   return false;
  }
 
  return true;
}
function trimAllSpace(str) 
{ 
    var str1 = ''; 
    var i = 0; 
    while(i != str.length) 
    { 
        if(str.charAt(i) != ' ') 
            str1 = str1 + str.charAt(i); i ++; 
    } 
    return str1; 
}
function trimString(str) 
{ 
     var str1 = ''; 
     var i = 0; 
     while ( i != str.length) 
     { 
         if(str.charAt(i) != ' ') str1 = str1 + str.charAt(i); i++; 
     }
     var retval = IsNumeric(str1); 
     if(retval == false) 
         return -100; 
     else 
         return str1; 
}
function IsNumeric(strString) 
{ 
    var strValidChars = "0123456789"; 
    var strChar; 
    var blnResult = true; 
    //var strSequence = document.frmQuestionDetail.txtSequence.value; 
    //test strString consists of valid characters listed above 
    if (strString.length == 0) 
        return false; 
    for (i = 0; i < strString.length && blnResult == true; i++) 
    { 
        strChar = strString.charAt(i); 
        if (strValidChars.indexOf(strChar) == -1) 
        { 
            blnResult = false; 
        } 
     }
     return blnResult; 
}
function getcycledata(data)
{
 $("input[id$='hdn_cycleid']").val(data);
  $("div[id$='div_save']").hide();
   $("div[id$='div_update']").show();
     $.ajax({
                url:"../Master/Default.aspx/Cycle_Time",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    for(var i=0;i<msg.d.length;i++)
                    {
                         $("select[id$='DropPart_cyc']").val(msg.d[i].Cpartno);
                         $("select[id$='Dropprocess_cyc']").val(msg.d[i].Cprocess);
                         $("input[id$='Text_cycle']").val(msg.d[i].Ctime);
                         $("input[id$='txt_seconds']").val(msg.d[i].Cseconds);
                    }
                },
                error:function()
                {}
              });
}
function deletecycledata(data)
{
    var con=window.confirm('Are You Sure Want To Delete This Registered Details');
    if(con==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/Deletecycleregister",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        alert("Record Deleted Successfully");
                        window.top.location.href="../Master/MasterFile.aspx";
                    }
                    else
                    {
                    }
                },
                error:function()
                {}
              });
    }
    else
    {
    }
    
}

function getmasterlinkpages()
{
 $.ajax({
                url:"../Master/Default.aspx/getmasterlink",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null && msg.d!="")
                    {
                    var tbl='';
                        for(var i=0;i<msg.d.length;i++)
                        {
                           var op='';
                           if(msg.d[i].Operation=='1' || msg.d[i].Operation=='2')
                           {
                            op='Operation '+msg.d[i].Operation;
                           }
                           else
                           {
                            op=msg.d[i].Operation;
                           }
                           var partno=msg.d[i].Partno;
                           var cell=msg.d[i].Cell;
//                           tbl+="<li ><a href='../DYNSheets/AdminSheet.html?partno="+msg.d[i].Partno+"&operation="+msg.d[i].Operation+"&unit=MBU&cell="+msg.d[i].Cell+"'>"+msg.d[i].Partno+" - "+op+"</a></li>";
                            tbl+="<li ><a href='../DYNSheets/AdminQulitySheet.aspx?partno="+msg.d[i].Partno+"&operation="+msg.d[i].Operation+"&unit=MBU&cell="+msg.d[i].Cell+"'>"+msg.d[i].Partno+" - "+op+"</a></li>";
                        }
                        $('#ul_productiondata').html(tbl);
                    }
                },
                error:function()
                {}
              });
}
