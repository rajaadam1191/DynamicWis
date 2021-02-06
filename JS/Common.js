function checkall()
{
        var f= document.getElementById("GridView1");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(document.getElementById("GridView1_ctl01_chkboxSelectAll").checked==true)
            {
                if(f.getElementsByTagName("input").item(i).type == "checkbox" )
                {
                   f.getElementsByTagName("input").item(i).checked=true;
                   $('#hdn_file').val('1');

                }  
            }
            
            if(document.getElementById("GridView1_ctl01_chkboxSelectAll").checked==false)
            {
                 if(f.getElementsByTagName("input").item(i).type == "checkbox" )
                {
                   f.getElementsByTagName("input").item(i).checked=false;
                   $('#hdn_file').val('');

                }  
            }
        }  
}

function showlfilingminus()
{
     $('#div_fillingminus').slideDown('slow');
     $('#div_fillingplus').slideUp('slow');
     $('#div_showfiling').slideDown('slow');
    $('#div_fillingplus').hide();
}
function showfillingplus()
{
    $('#div_fillingplus').slideDown('slow');
     $('#div_fillingminus').slideUp('slow');
     $('#div_showfiling').slideUp('slow');
    $('#div_fillingminus').hide();
}    
function showlarchgminus()
{
     $('#div_archminus').slideDown('slow');
     $('#div_archplus').slideUp('slow');
     $('#div_showarch').slideDown('slow');
    $('#div_archplus').hide();
}
function showarchplus()
{
    $('#div_archplus').slideDown('slow');
     $('#div_archminus').slideUp('slow');
     $('#div_showarch').slideUp('slow');
    $('#div_archminus').hide();
}    

function showdesminus()
{
     $('#div_desminus').slideDown('slow');
     $('#div_desplus').slideUp('slow');
     $('#div_description').slideDown('slow');
    $('#div_desplus').hide();
}
function showesplus()
{
    $('#div_desplus').slideDown('slow');
     $('#div_desminus').slideUp('slow');
     $('#div_description').slideUp('slow');
    $('#div_desminus').hide();
}    


function getfromtime(data)
{
    var fromtime=$("input[id$='"+data+"']").val();
    if(fromtime=="" || fromtime==null)
    {
        $(data).focus();
        return false;
    }
    else
    {
        var dTime = new Date();

       var hours = dTime.getHours();

      var minute = dTime.getMinutes();

       var period = "AM";

      if (hours > 12) {

           period = "PM"

        }

      else {

           period = "AM";

    }

       hours = ((hours > 12) ? hours - 12 : hours)

       $("input[id$='"+data+"']").val(hours + ":" + minute + " " + period);
       
//         $.ajax({
//                url:"../Master/Default.aspx/gettime",
//                data:"{}",
//                type:"POST",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg)
//                {
//                    if(msg.d=="" || msg.d==null)
//                    {
//                    }
//                    else
//                    {
//                       $("input[id$='"+data+"']").val(msg.d);
//                    }
//                },
//                error:function()
//                {}
//              });
    }
}
function startime(from,to,total)
{
    var fromt=$("input[id$='"+from+"']").val();
    if(fromt=="" || fromt==null)
    {
         var totime=$("input[id$='"+to+"']").val('');
         var ttime=$("input[id$='"+total+"']").val('');
         $("input[id$='"+from+"']").focus();        
    }
   
}
function gettotime(from,to,total)
{
    var totime=$("input[id$='"+to+"']").val();
    if(totime=="" || totime==null)
    {
        $('#txt_totime').focus();
        return false;
    }
    else
    {
     var dTime = new Date();

       var hours = dTime.getHours();

      var minute = dTime.getMinutes();

       var period = "AM";

      if (hours > 12) {

           period = "PM"

        }

      else {

           period = "AM";

    }

       hours = ((hours > 12) ? hours - 12 : hours)

       $("input[id$='"+to+"']").val(hours + ":" + minute + " " + period);
       gettotaltime(from,to,total);
//        $.ajax({
//                url:"../Master/Default.aspx/gettime",
//                data:"{}",
//                type:"POST",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg)
//                {
//                    if(msg.d=="" || msg.d==null)
//                    {
//                    }
//                    else
//                    {
//                       $("input[id$='"+to+"']").val(msg.d);
//                       
//                    }
//                },
//                error:function()
//                {}
//              });
    }
}
function gettotaltime(from,to,total)
{
    var fromtime=$("input[id$='"+from+"']").val();
    var totime=$("input[id$='"+to+"']").val();
    if(fromtime!="" && fromtime!=null && totime!="" &&  totime!=null)
    {
                var start = fromtime;
                var end = totime;
                start=start.replace("AM","");
                start=start.replace("PM","");
                end=end.replace("AM","");
                end=end.replace("PM","");
                s = start.split(':');
                e = end.split(':');

                min = e[1]-s[1];
                hour_carry = 0;
                 
                if(min < 0){
                    min += 60;
                    hour_carry += 1;
                }
               if(min<=9)
               {
                min="0"+min;
               }
              
                hour = e[0]-s[0]-hour_carry;
                 if(hour<=9)
               {
                hour="0"+hour;
               }
                diff = hour + ":" + min;
                 $("input[id$='"+total+"']").val(diff);
    
//        $.ajax({
//                url:"../Master/Default.aspx/get_time",
//                data:"{'fromtime':'"+fromtime+"','totime':'"+totime+"'}",
//                type:"POST",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg)
//                {
//                    if(msg.d=="" || msg.d==null)
//                    {
//                    }
//                    else
//                    {
//                       $("input[id$='"+total+"']").val(msg.d);
//                    }
//                },
//                error:function()
//                {}
//              });
    }
}
function loginvalidation()
{
    if(!validate_username())return false
    if(!validate_password())return false
    if(!validate_shift())return false
    
}
function validate_username()
{
    var username=$('#txtName').val();
  
    if(username=="" || username ==null)
    {
       // $('#txtName').focus();
        $('#div_error').show();
        $('#sp_error').text('Enter User Name');
        return false;
    }
    else
    {
        $('#div_error').hide();
        return true;
    }
    
}
function validate_password()
{
     var pwrd=$('#txtPassword').val();
    if(pwrd=="" || pwrd ==null)
    {
//        $('#txtPassword').focus();
      $('#div_error').show();
        $('#sp_error').text('Enter Password');
        return false;
    }
    else
    {
        $('#div_error').hide();
        return true;
    }
}
function validate_shift()
{
   var user=$('#hdn_shift').val();
   
   if(user=="User" || user=="" ||user==null )
   {
   
        var shift=$('#ddl_shift').val();
        
        if(shift=="0" || shift ==null || shift=="-Select-")
        {
       
            $('#ddl_shift').focus();
            $('#div_error').show();
            $('#sp_error').text('Select Shift');
            return false;
        }
        else
        {
            $('#div_error').hide();
            return true;
        }
    
    }
    else{
    return true;
    }
}
function validatepid()
{
    if(!validate_pidno())return false
}
function validate_pidno()
{
    var pid=$('#txt_pidno').val();
    
    if(pid=="" || pid==null)
    {
        $('#diverror').show();
        $('#spn_error').text('Select PID No');
        $('#txt_pidno').focus();
        return false;
        
    }
    else
    {
        $('#diverror').hide();
        return true;
    }
}

function getRejection(partno,shift,operation,date)
{
    var result=validateRejection();
    if(result=="S")
    {
        var prt=$("select[id$='DropPartNo']").val();
        var date=$("input[id$='TxtDateTime']").val();
        var shift=$("select[id$='DropShift']").val();
        var Process=$("select[id$='DropOperation']").val();
        $.ajax({
                url:"../Master/Default.aspx/getRejection",
                data:"{'prt':'"+prt+"','date':'"+date+"','shift':'"+shift+"','Process':'"+Process+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    var date=$("input[id$='TxtRejection']").val(msg.d);
                    
                },
                error:function()
                {}
              });
        
    }
}
function getRejection1(partno,shift,operation,date)
{
        $.ajax({
                url:"../Master/Default.aspx/getRejection",
                data:"{'prt':'"+partno+"','date':'"+date+"','shift':'"+shift+"','Process':'"+operation+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    var date=$("input[id$='txt_rejection']").val(msg.d);
                    
                },
                error:function()
                {}
              });
        
}
function validateRejection()
{
    var R;
    if(!validate_Rpartno())return false
    if(!validate_Rprocess())return false
    if(!validate_Rshift())return false
    
    R="S";
    return R;
}
function validate_Rpartno()
{
    var p=$("select[id$='DropPartNo']").val();
    if(p=="" || p=="0" || p==null || p=="-Select-")
    {
           alert('Please Select PartNo');
           $("select[id$='DropPartNo']").focus();
           return false;
    }
    else
    {
        return true;
    }
}
function validate_Rprocess()
{
    var p=$("select[id$='DropOperation']").val();
    if(p=="" || p=="0" || p==null || p=="-Select-")
    {
           alert('Please Select Process');
           $("select[id$='DropOperation']").focus();
           return false;
    }
    else
    {
        return true;
    }
}
function validate_Rshift()
{
    var p=$("select[id$='DropShift']").val();
    if(p=="" || p=="0" || p==null || p=="-Select-")
    {
           alert('Please Select Shift');
           $("select[id$='DropShift']").focus();
           return false;
    }
    else
    {
        return true;
    }
}

function showdimesionone()
{
   // var res=checkchart();
    //if(res==true)
    //{
    var user=$("input[id$='hdn_user']").val();
    if(user=="User")
    {
       
        
        window.top.location.href='ViewQChart.aspx';
    }
    else
    {
        var Cpart=$("select[id$='ddl_partno']").val();
        var Coper=$("select[id$='ddl_operation']").val();
        var Cfrom=$("input[id$='txt_fromdate']").val();
        var Cto=$("input[id$='txt_todate']").val();
         var type=$("select[id$='ddl_type']").val();
        var shift=$("select[id$='ddl_shift']").val();
          var mchn=$("select[id$='Slct_machine_QC_chart']").val();
        
        var unit=$("select[id$='ddl_unit_QC_chart']").val();
       
        
        
        window.top.location.href='ViewQChart.aspx?Type='+type+'&Partno='+Cpart+'&Operation='+Coper+'&fromdate='+Cfrom+'&todate='+Cto+'&shift='+shift+'&mchn='+mchn+'&unit='+unit+'';
    }
        
    //}
}
function showdimesiontwo()
{
    //var res=checkchart();
    //if(res==true)
    //{
     var user=$("input[id$='hdn_user']").val();
    if(user=="User")
    {
       
        window.top.location.href='ViewChartD2.aspx';
    }
    else
    {
        var Cpart=$("select[id$='ddl_partno']").val();
        var Coper=$("select[id$='ddl_operation']").val();
        var Cfrom=$("input[id$='txt_fromdate']").val();
        var Cto=$("input[id$='txt_todate']").val();
        var type=$("select[id$='ddl_type']").val();
        var shift=$("select[id$='ddl_shift']").val();
         var mchn=$("select[id$='Slct_machine_QC_chart']").val();
//         var mchn=$.session.get('mchn');
//         alert(mchn);
        var unit=$("select[id$='ddl_unit_QC_chart']").val();
        
        window.top.location.href='ViewChartD2.aspx?Type='+type+'&Partno='+Cpart+'&Operation='+Coper+'&fromdate='+Cfrom+'&todate='+Cto+'&Shift='+shift+'&mchn='+mchn+'&unit='+unit+'';
    }
//     $("div[id$='div_dimestiontwo']").load('ViewQChartD2.aspx?Partno='+Cpart+'&Operation='+Coper+'&fromdate='+Cfrom+'&todate='+Cto);
    //}
}
function showdimesionthree()
{
   // var res=checkchart();
    //if(res==true)
    //{var user=$("input[id$='hdn_user']").val();
     var user=$("input[id$='hdn_user']").val();
    if(user=="User")
    {
       
        window.top.location.href='ViewChartD3.aspx';
    }
    else
    {
        var Cpart=$("select[id$='ddl_partno']").val();
        var Coper=$("select[id$='ddl_operation']").val();
        var Cfrom=$("input[id$='txt_fromdate']").val();
        var Cto=$("input[id$='txt_todate']").val();
        var type=$("select[id$='ddl_type']").val();
        var shift=$("select[id$='ddl_shift']").val();
           var mchn=$("select[id$='Slct_machine_QC_chart']").val();
//            var mchn=$.session.get('mchn');
//         alert(mchn);
        var unit=$("select[id$='ddl_unit_QC_chart']").val();
        
       
        window.top.location.href='ViewChartD3.aspx?Type='+type+'&Partno='+Cpart+'&Operation='+Coper+'&fromdate='+Cfrom+'&todate='+Cto+'&Shift='+shift+'&mchn='+mchn+'&unit='+unit+'';
    }
//     $("div[id$='div_dimestionthree']").load('ViewQChartD3.aspx?Partno='+Cpart+'&Operation='+Coper+'&fromdate='+Cfrom+'&todate='+Cto);
   // }
}
function showdimesionfour()
{
  //  var res=checkchart();
   // if(res==true)
   // {
     var user=$("input[id$='hdn_user']").val();
    if(user=="User")
    {
       
        window.top.location.href='ViewChartD4.aspx';
    }
    else
    {
         var Cpart=$("select[id$='ddl_partno']").val();
        var Coper=$("select[id$='ddl_operation']").val();
        var Cfrom=$("input[id$='txt_fromdate']").val();
        var Cto=$("input[id$='txt_todate']").val();
        var type=$("select[id$='ddl_type']").val();
        var shift=$("select[id$='ddl_shift']").val();
        var mchn=$("select[id$='Slct_machine_QC_chart']").val();
//         var mchn=$.session.get('mchn');
//         alert(mchn);
        var unit=$("select[id$='ddl_unit_QC_chart']").val();
        
        window.top.location.href='ViewChartD4.aspx?Type='+type+'&Partno='+Cpart+'&Operation='+Coper+'&fromdate='+Cfrom+'&todate='+Cto+'&Shift='+shift+'&mchn='+mchn+'&unit='+unit+'';
     }
//     $("div[id$='div_dimestionfour']").load('ViewQChartD4.aspx?Partno='+Cpart+'&Operation='+Coper+'&fromdate='+Cfrom+'&todate='+Cto);
   // }
}

function viewallchart(parno,operation,fromdate,tt)
{
    $("div[id$='div_dimestiontwo']").load('ViewQChartD2.aspx?Partno='+parno+'&Operation='+operation+'&fromdate='+fromdate+'&todate='+tt);
    $("div[id$='div_dimestionthree']").load('ViewQChartD3.aspx?Partno='+parno+'&Operation='+operation+'&fromdate='+fromdate+'&todate='+tt);
    if(parno=="32271" || parno=="44983")
    {
        $("div[id$='div_dimestionfour']").load('ViewQChartD4.aspx?Partno='+parno+'&Operation='+operation+'&fromdate='+fromdate+'&todate='+tt)
    }
    
}
function validate_Pshift11()
{

     var shift11=$("select[id$='ddl_shift']").val();
    if(shift11=="0" || shift11=="-Select-")
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Select Shift');
        $("select[id$='ddl_shift']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        if(shift11=="A")
        {
         $("input[id$='txt_shift']").val('6:00 AM to 2:00 PM');
         }
          if(shift11=="B")
        {
         $("input[id$='txt_shift']").val('2:00 PM to 10:00 PM');
         }
          if(shift11=="C")
        {
         $("input[id$='txt_shift']").val('10:00 PM to 6:00 AM');
         }
          if(shift11=="A1")
        {
         $("input[id$='txt_shift']").val('6:00 AM to 6:00 PM');
         }
          if(shift11=="B1")
        {
         $("input[id$='txt_shift']").val('6:00 PM to 6:00 AM');
         }
         var shhift=$("input[id$='txt_shift']").val();
         $("input[id$='Hdn_shift']").val(shhift);
        return true;
    }
}
function validateTimemaster()
{
    if(!validate_Tpartno())return false
    if(!validate_Tprocess())return false
    if(!validate_Tbotele())return false
    if(!validate_TT())return false
}
function validate_Tpartno()
{
    var Tpartno=$("select[id$='DropPartNo']").val();
    if(Tpartno=="" || Tpartno==null || Tpartno=="0" || Tpartno=="-Select-")
    {
        $("select[id$='DropPartNo']").addClass('errormessage');
       // $("select[id$='DropPartNo']").focus();
        return false;
    }
    else
    {
        $("select[id$='DropPartNo']").removeClass('errormessage');
        return true;
    }
}
function validate_Tprocess()
{
     var Topertaion=$("select[id$='DropOperation']").val();
    if(Topertaion=="" || Topertaion==null || Topertaion=="0" || Topertaion=="-Select-")
    {
        $("select[id$='DropOperation']").addClass('errormessage');
        //$("select[id$='DropOperation']").focus();
        return false;
    }
    else
    {
        $("select[id$='DropOperation']").removeClass('errormessage');
        return true;
    }
}
function validate_Tbotele()
{
    var tbottle=$("input[id$='TxtBottleNeckTime']").val();
    if(tbottle=="" || tbottle==null)
    {
        $("input[id$='TxtBottleNeckTime']").addClass('errormessage');
       // $("input[id$='TxtBottleNeckTime']").focus();
        return false;
    }
    else
    {
        $("input[id$='TxtBottleNeckTime']").removeClass('errormessage');
        return true;
    }
}
function validate_TT()
{
     var TT=$("input[id$='TxtTt']").val();
    if(TT=="" || TT==null)
    {
        $("input[id$='TxtTt']").addClass('errormessage');
       // $("input[id$='TxtTt']").focus();
        return false;
    }
    else
    {
        $("input[id$='TxtTt']").removeClass('errormessage');
        return true;
    }
}
function deletetimemaster(data)
{
    var con=window.confirm('Are You Sure Want To Delete This Registered Details');
    if(con==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/Deletetimeregister",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        alert("Record Deleted Successfully");
                        window.top.location.href="../Master/Time_Master.aspx";
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
function gettimemaster(data)
{
 $("input[id$='hdn_timeid']").val(data);
  $("div[id$='div_save']").hide();
   $("div[id$='div_update']").show();
     $.ajax({
                url:"../Master/Default.aspx/GetTimeValues",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    for(var i=0;i<msg.d.length;i++)
                    {
                        
                         $("select[id$='DropPartNo']").val(msg.d[i].Tpartno);
                         $("select[id$='DropOperation']").val(msg.d[i].Toperation);
                         $("input[id$='TxtBottleNeckTime']").val(msg.d[i].Tbottle);
                         $("input[id$='TxtTt']").val(msg.d[i].TTT);
                    }
                },
                error:function()
                {}
              });
}
function laborefficiency()
{

    var LEdate=$("input[id$='txt_date']").val();
    var LEShift=$("select[id$='ddl_shift']").val();
     var LEmachn=$("select[id$='Slct_machine_eff_LE']").val();
      var LEunit=$("select[id$='ddl_unit_LBeff']").val();

     $.ajax({
                url:"../Master/Default.aspx/laborEff1",
                data:"{'date':'"+LEdate+"','shift':'"+LEShift+"','mchn':'"+LEmachn+"','unit':'"+LEunit+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!="" && msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            showerromessage1(msg.d[i].errormessage);
                            $("input[id$='Text_earn']").val(msg.d[i].val);
                        }
                    }
                    else
                    {
                        
                    }
              },
                error:function()
                {}
              });
}
function actualtym()
{
 var earn=$("input[id$='Text_earn']").val();
 var actual=$("input[id$='Text_actual']").val();
 var seconds=$("input[id$='txt_seconds']").val();
    $.ajax({
                url:"../Master/Default.aspx/ttlEff",
                data:"{'Earndtm':'"+earn+"','actualtm':'"+actual+"','Seconds':'"+seconds+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                 $("input[id$='ttl_tim']").val(msg.d);
                },
                error:function()
                {}
              });
}
function allow_number(a)
{

 if (a.value.match(/[^0-9]/g)) 
 {
   a.value = a.value.replace(/[^0-9.]/g,'');
   
 }
}
function validatePD()
{
    if(!validate_Ptype())return false
    if(!validate_PProcess())return false
    if(!validate_Pfile())return false
    if(!validate_Pcheckbox())return false
}
function validate_Ptype()
{
    var ptype=$('#DropType').val();
    if(ptype=="" || ptype=="0" || ptype==null || ptype=="-Select-")
    {
        $("div[id$='div_error']").show();
        $("span[id$='spnerror']").text('Please Select Type');
        $("select[id$='DropType']").focus();
        //$("select[id$='ddl_partno']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
    
}
function validate_PProcess()
{
    var pprocess=$('#DropProcess').val();
    var ptype1=$('#DropType').val();
    if(ptype1=="1")
    {
            if(pprocess=="" || pprocess=="0" || pprocess==null || pprocess=="-Select-")
            {
                 $("div[id$='div_error']").show();
        $("span[id$='spnerror']").text('Please Select Process');
        $("select[id$='DropProcess']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
    }
    else
    {
        return true;
    }
}
function validate_Pfile()
{
   var Files = document.getElementById("FileUpload1").value;
   if(Files=="" || Files == "0" || Files==null)
   {
        $("div[id$='div_error']").show();
        $("span[id$='spnerror']").text('Please Select File');
        $("select[id$='FileUpload1']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Pcheckbox()
{
    var checkselect=$('#hdn_file').val();
    if(checkselect=="" || checkselect==null)
    {
     $("div[id$='div_error']").show();
        $("span[id$='spnerror']").text('Please Select Atleast One Part No');
        //$("select[id$='ddl_partno']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function checkgridcheckbox()
{
     var f= document.getElementById("GridView1");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "checkbox" )
            {
                if(f.getElementsByTagName("input").item(i).checked==true)
                {   
                    $('#hdn_file').val('1');
                }
            }  
        }  
}
//function lap_drp()
//{
//    if(!validate_ddrp())return false
//}
//function validate_ddrp()
//{
// var dpid=$('#ddl_PIDNo').val();
//    if(dpid=="" || dpid=="0" || dpid==null || dpid=="-Select-")
//    {
//        $('#ddl_PIDNo').focus();
//        alert("Select PID NO");
//        return false;
//    }
//    else
//    {
//        return true;
//    }
//}
function validate_loginshift()
{
    var username=$('#txtName').val();
    var password=$('#txtPassword').val();
    $.ajax({
                url:"Master/Default.aspx/checkuser_shift",
                data:"{'Username':'"+username+"','Password':'"+password+"'}",
                type:"POST",
                contentType:"application/json; charset=utf-8",
                dataType:"json",
                success: function(msg)
                {
               
                if(msg.d=="F")
                {
                    
                       $('#txtName').val('');
                       $('#txtPassword').val('');
                        $('#txtName').focus();
                         $('#div_error').show();
                         $('#sp_error').text('Invalid UserName and Password');
                }
                else
                {
                    $('#hdn_shift').val(msg.d);
                    if(msg.d=="Super Admin" || msg.d=="Admin" )
                     {
                     document.getElementById("ddl_shift").setAttribute('disabled', true);
                     $('#ddl_shift').val('0');
                     } 
                     else if(msg.d=="User")
                     {
                       var shift=$('#ddl_shift').val();
                        if(shift=="0" || shift ==null)
                        {
                        $('#ddl_shift').focus();
                         $('#div_error').show();
                         $('#sp_error').text('Select Shift');
                          }
                        else
                        {
                            $('#div_error').hide();
                        }
                     }
                     else
                     {
                     }
                }
                 
                },
                error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.status);
                        alert(thrownError);}
              });
    
}
function changefocus()
{
     
    var actual=$("input[id$='Text_actual']").val();
    if(actual!="" && actual!=null)
    {
        $("input[id$='txt_seconds']").focus();
    }
    else
    {
        $("input[id$='Text_actual']").focus();
    }
}


$(function ()
{
    $('#ddl_unit').change(function()
    {
        var unit=$('#ddl_unit').val();
        if(unit=="ABU")
        {
     var url="../ABU/Login.aspx";
     window.top.location.href=url;
        }
        if(unit=="MBU")
        {
            $('#div_mbu').show();
            $('#div_assem').hide();
            $('#div_abu').hide();
        }
    });
});


function login_validation()
{
    if(!validate_username1())return false
    if(!validate_password1())return false
   
    
}
function validate_username1()
{
    var username=$('#txt_ausername').val();
  
    if(username=="" || username ==null)
    {
       // $('#txtName').focus();
        $('#div_error').show();
        $('#sp_error').text('Enter User Name');
        return false;
    }
    else
    {
        $('#div_error').hide();
        return true;
    }
    
}
function validate_password1()
{
     var pwrd=$('#txt_apassword').val();
    if(pwrd=="" || pwrd ==null)
    {
//        $('#txtPassword').focus();
      $('#div_error').show();
        $('#sp_error').text('Enter Password');
        return false;
    }
    else
    {
        $('#div_error').hide();
        return true;
    }
}

$(function()
{
    $('#div_abu').click(function()
    {
        var url="ABU/Login.aspx";
        window.top.location.href=url;
    });
});


$(function()
{
    $('#div_mbu').click(function()
    {
        var url="index.aspx";
        window.top.location.href=url;
    });
});
