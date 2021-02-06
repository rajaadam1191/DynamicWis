var pmaintenanc;
var clean;
var break1;
var demand;
var trials;
var meetings;
var traing;
var plnmaintenance;
var prdqty;
var cmm;
var qualityissues;
var rework;
var rejection;
var speedtot;
var downtot;
var utiletime;
var speedtype;
var downtype;
var accept;

$(document).ready(function()
{
   getpageloadvalues(); 
});
function getpageloadvalues()
{
    $.ajax({
                url:"../Master/Default.aspx/checkpageload",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
              
                    if(msg.d=="F")
                    {
                        window.location.href="../Home.aspx";
                    }
                    else
                    {
                        if(msg.d=="User")
                        {
                       
                            $('#div_user').show();
                            $('#super_admin').hide();
//                             GetPartno();
//                             GetProcess();
                             Effloadpage();
                         
                        }
                        
                        if(msg.d=="Super Admin")
                        {
                            $('#super_admin').show();
                            $('#div_user').hide();
                             GetPartno();
                             GetProcess();
                        }
                    }
                },
                error:function()
                {}
              });
}
function getSpeedlossvalues(pmaintenanc,clean,break1,demand,trials,meetings,traing,plnmaintenance)
{
   var table='';
    var partno= $("#hdn_part").val();
    var process= $("#hdn_process").val();
    var machinename=$('#hdn_machine').val();
    var pidno=$('#hdn_pidno').val();
    var cell=$('#txt_dept').text();
    if(process =="OP1")
    {
        table='QualitySheet_'+cell+'_'+partno+'_1';
    }
    else if(process =="OP1")
    {
        table='QualitySheet_'+cell+'_'+partno+'_2';
    }
    else
    {
        table='QualitySheet_'+cell+'_'+partno+'_'+process;
    }
//    //Q
//    if(partno=="A17724Q" && process=="OP1")
//    {
//        table="QualitySheet";
//    }
//    if(partno=="A17724Q" && process=="OP2")
//    {
//        table="opt2QSA17724Q";
//    }
//    if(partno=="A17724Q" && process=="Polishing")
//    {
//        table="QSheetPolishing24Q";
//    }
//     if(partno=="A17724Q" && process=="Lapping")
//    {
//        table="lappingQsheet24Q";
//    }
//    //J
//     if(partno=="A22916J" && process=="OP1")
//    {
//        table="QualitySheetA22916J";
//    }
//    if(partno=="A22916J" && process=="OP2")
//    {
//        table="opt2QualitySheetA22916J";
//    }
//    if(partno=="A22916J" && process=="Polishing")
//    {
//        table="QSheetpolishingA22916J";
//    }
//     if(partno=="A22916J" && process=="Lapping")
//    {
//        table="lappingQsheet24Q";
//    }
//    //C
//     if(partno=="A32271C" && process=="OP1")
//    {
//        table="QSheetA32271C";
//    }
//    if(partno=="A32271C" && process=="Polishing")
//    {
//        table="QSheetpolishingA32271C";
//    }
//     if(partno=="A32271C" && process=="Lapping")
//    {
//        table="lappingQsheet24Q";
//    }
//    //N
//     if(partno=="A44908N" && process=="OP1")
//    {
//        table="QSheetA44908N";
//    }
//    if(partno=="A44908N" && process=="Polishing")
//    {
//        table="QSheetPolishingA44908N";
//    }
//     if(partno=="A44908N" && process=="Lapping")
//    {
//        table="lappingQsheet24Q";
//    }
//    //U
//     if(partno=="A44983U" && process=="OP1")
//    {
//        table="qualityshtA44983U";
//    }
//    if(partno=="A44983U" && process=="Polishing")
//    {
//        table="QSheetpolishingA44983U";
//    }
//     if(partno=="A44983U" && process=="Lapping")
//    {
//        table="lappingQsheet24Q";
//    }
    var shift= $("#hdn_shift").val();
    var main=parseInt(pmaintenanc);
    var clean=parseInt(clean);
    var break1=parseInt(break1);
    var demand=parseInt(demand);
    var trail=parseInt(trials);
    var meeting=parseInt(meetings);
    var traing=parseInt(traing);
    var plnmaintenance=parseInt(plnmaintenance);
     $.ajax({
                url:"../Master/Default.aspx/Getfixedtime",
                data:"{'Partno':'"+partno+"','Process':'"+process+"','Shift':'"+shift+"','Table':'"+table+"','Machine':'"+machinename+"','PIDNO':'"+pidno+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                   var totaltime=parseInt(msg.d);
                   var actualtime=totaltime-(parseInt(main+clean+break1+demand+trail+meeting+traing+plnmaintenance));
                   if(parseInt(actualtime)>0)
                   {
                   
                        $('#txt_availabletime').text(actualtime);
                       //$('#txt_speedtotal').text($('#txt_availabletime').text());
                         
                   }
                   else
                   {
                        alert("Speed Loss value are lower than zero");
                        $('#txt_speedtotal').text('0');
                        $('#txt_availabletime').text('0');
                   }
                   showbalancesppedloss();
                    
                },
                error:function()
                {}
              });
}


function showbalancesppedloss()
{
    var partno= $("#hdn_part").val();
    var process= $("#hdn_process").val();
    var machinename=$('#hdn_machine').val();
    var pidno=$('#hdn_pidno').val();
    var shift=$('#hdn_shift').val();
    var speedloss =$('#txt_availabletime').text();

        $.ajax({
                url:"../Master/Default.aspx/Getfixe_dtime",
                data:"{'Partno':'"+partno+"','Process':'"+process+"','Shift':'"+shift+"','Machine':'"+machinename+"','PIDNO':'"+pidno+"','Speedloss':'"+speedloss+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!="" && msg.d!=null)
                    {
                    
                        $('#txt_speedtotal').text(msg.d);
                        showbalancesppedloss1();
                    }
                    else
                    {
                    }
                     
                    
                },
                error:function()
                {}
              });

}
function showbalancesppedloss1()
{
    var partno= $("#hdn_part").val();
    var process= $("#hdn_process").val();
    var machinename=$('#hdn_machine').val();
    var pidno=$('#hdn_pidno').val();
    var shift=$('#hdn_shift').val();
 

        $.ajax({
                url:"../Master/Default.aspx/Getfixe_dtime1",
                data:"{'Partno':'"+partno+"','Process':'"+process+"','Shift':'"+shift+"','Machine':'"+machinename+"','PIDNO':'"+pidno+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!="" && msg.d!=null)
                    {
                    
                        $('#spn_totalspeed').text(msg.d);
                    }
                    else
                    {
                    }
                     
                    
                },
                error:function()
                {}
              });

}


function GetProcess()
{
    var comma=null;
var part=[];
    $.ajax({
                
            
                url:"../Master/Default.aspx/Get_prtprocess",
               // data:"{}",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("#ddl_operation").get(0).options.length = 0;
                    $("#ddl_operation").get(0).options[0] = new Option("-Select-", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("#ddl_operation").get(0).options[$("#ddl_operation").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    
                },
                error:function()
                {}
        });
}
function GetPartno()
{
    var comma=null;
var part=[];
    $.ajax({
                
            
                url:"../Master/Default.aspx/Get_prtno",
               // data:"{}",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("#ddl_partno").get(0).options.length = 0;
                    $("#ddl_partno").get(0).options[0] = new Option("-Select-", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("#ddl_partno").get(0).options[$("#ddl_partno").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    
                },
                error:function()
                {}
        });
}
function Effloadpage()
{
    $.ajax({
                url:"../Master/Default.aspx/Effpageload",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                   for(var i=0;i<msg.d.length;i++)
                   {
                  
                      if(msg.d[i].errormessage=="")
                      {
                      //
                      $('#hdn_pidno').val(msg.d[i].pidn);
                       $('#ddl_partno').text(msg.d[i].partno);
                       $('#hdn_part').val(msg.d[i].partno);
                       //$('#ddl_partno').attr('disabled','disabled');
                       $('#ddl_operation').text(msg.d[i].operation);
                       $('#hdn_process').val(msg.d[i].operation);
                        //$('#ddl_operation').attr('disabled','disabled');
                        $('#txt_dept').text(msg.d[i].dept);
                       // $('#txt_dept').attr('disabled','disabled');
                        $('#txt_unit').text(msg.d[i].ut);
                       $('#hdn_unit').val(msg.d[i].ut);
                        $('#txt_machinename').text(msg.d[i].mchn);
                        $('#hdn_machine').val(msg.d[i].mchn);
                        //$('#txt_machinename').attr('disabled','disabled');
                        $('#txt_date').text(msg.d[i].Datetime);
                        //$('#txt_date').attr('disabled','disabled');
                        $('#ddl_shift').text(msg.d[i].shift);
                         $('#hdn_shift').val(msg.d[i].shift);
                        //$('#ddl_shift').attr('disabled','disabled');
                        $('#ddl_fromtime').text(msg.d[i].shiftime);
                       // $('#ddl_fromtime').attr('disabled','disabled');
                        //$('#ddl_totime').attr('disabled','disabled');
                        //$('#txt_shifttime').attr('disabled','disabled');
                       // $('#ddl_fromampm').attr('disabled','disabled');
                       // $('#ddl_toampm').attr('disabled','disabled');
                       // $('#txt_shifthrs').attr('disabled','disabled');
                        if(msg.d[i].shift=="A")
                        {
                           // $('#ddl_fromtime').val('6');
                           // $('#ddl_totime').val('2');
                            $('#txt_shifthrs').text('8');
                            
                        }
                         if(msg.d[i].shift=="B")
                        {
                            // $('#ddl_fromtime').val('2');
                           // $('#ddl_totime').val('10');
                            $('#txt_shifthrs').text('8');
                        }
                         if(msg.d[i].shift=="C")
                        {
                            // $('#ddl_fromtime').val('10');
                           // $('#ddl_totime').val('6');
                            $('#txt_shifthrs').text('8');
                        }
                         if(msg.d[i].shift=="A1")
                        {
                            //$('#ddl_fromtime').val('6');
                           // $('#ddl_totime').val('6');
                            $('#txt_shifthrs').text('12');
                        }
                         if(msg.d[i].shift=="B1")
                        {
                            // $('#ddl_fromtime').val('6');
                           // $('#ddl_totime').val('6');
                            $('#txt_shifthrs').text('12');
                        }
                        
                        $('#txt_operatorname').text(msg.d[i].Username);
                       // $('#txt_operatorname').attr('disabled','disabled');
                        if(msg.d[i].pmaintenance ==null || msg.d[i].pmaintenance=="")
                        {
                        $('#txt_pmaintenance').text(msg.d[i].pmaintenance);
                       // $('#txt_pmaintenance').attr('disabled','disabled');
                        msg.d[i].pmaintenance="0";
                       
                        }
                         if(msg.d[i].pmaintenance !=null || msg.d[i].pmaintenance!="")
                        {
                        $('#txt_pmaintenance').text(msg.d[i].pmaintenance);
                       // $('#txt_pmaintenance').attr('disabled','disabled');
                       
                        }
                       if(msg.d[i].cleaning ==null || msg.d[i].cleaning=="")
                        {
                        $('#txt_clean').text(msg.d[i].cleaning);
                        //$('#txt_clean').attr('disabled','disabled');
                        msg.d[i].Tea="0";
                        }
                        if(msg.d[i].cleaning !=null || msg.d[i].cleaning !="")
                        {
                        $('#txt_clean').text(msg.d[i].cleaning);
                       // $('#txt_clean').attr('disabled','disabled');
                        }
                        if(msg.d[i].break1==null || msg.d[i].break1=="")
                        {
                        $('#txt_break').text(msg.d[i].break1);
                       // $('#txt_break').attr('disabled','disabled');
                        msg.d[i].break1="0";
                        }
                        if(msg.d[i].break1!=null || msg.d[i].break1!="")
                        {
                        $('#txt_break').text(msg.d[i].break1);
                      //  $('#txt_break').attr('disabled','disabled');
                        }
                        if(msg.d[i].noplan==null || msg.d[i].noplan=="")
                        {
                        $('#txt_demand').text(msg.d[i].noplan);
                      //  $('#txt_demand').attr('disabled','disabled');
                        msg.d[i].noplan="0";
                        }
                         if(msg.d[i].noplan!=null || msg.d[i].noplan!="")
                        {
                        $('#txt_demand').text(msg.d[i].noplan);
                       // $('#txt_demand').attr('disabled','disabled');
                     
                        }
                        if(msg.d[i].trials==null || msg.d[i].trials=="")
                        {
                        $('#txt_trails').text(msg.d[i].trials);
                       // $('#txt_trails').attr('disabled','disabled');
                        msg.d[i].trials="0";
                        }
                        if(msg.d[i].trials!=null || msg.d[i].trials!="")
                        {
                        $('#txt_trails').text(msg.d[i].trials);
                       // $('#txt_trails').attr('disabled','disabled');
                        }
                        if(msg.d[i].meeitngs==null || msg.d[i].meeitngs=="")
                        {
                        $('#txt_meeting').text(msg.d[i].meeitngs);
                      //  $('#txt_meeting').attr('disabled','disabled');
                        msg.d[i].meeitngs="0";
                        }
                         if(msg.d[i].meeitngs !=null || msg.d[i].meeitngs !="")
                        {
                        $('#txt_meeting').text(msg.d[i].meeitngs);
                      //  $('#txt_meeting').attr('disabled','disabled');
                       
                        }
                        if(msg.d[i].trainings==null || msg.d[i].trainings=="")
                        {
                        $('#txt_trainig').text(msg.d[i].trainings);
                       // $('#txt_trainig').attr('disabled','disabled');
                        msg.d[i].trainings="0";
                        }
                         if(msg.d[i].trainings !=null || msg.d[i].trainings !="")
                        {
                        $('#txt_trainig').text(msg.d[i].trainings);
                        //$('#txt_trainig').attr('disabled','disabled');
                       
                        }
                        if(msg.d[i].plnmaintenance==null || msg.d[i].plnmaintenance=="")
                        {
                        $('#txt_plnmaintenace').text(msg.d[i].plnmaintenance);
                       // $('#txt_plnmaintenace').attr('disabled','disabled');
                        msg.d[i].plnmaintenance="0";
                        }
                         if(msg.d[i].plnmaintenance !=null || msg.d[i].plnmaintenance !="")
                        {
                        $('#txt_plnmaintenace').text(msg.d[i].plnmaintenance);
                       // $('#txt_plnmaintenace').attr('disabled','disabled');
                       
                        }
                        $('#txt_prodqty').text(msg.d[i].accept);
                      
                       // $('#txt_prodqty').attr('disabled','disabled');
                        
                        $('#txt_rejection').text(msg.d[i].Rejection);
                       // $('#txt_rejection').attr('disabled','disabled');
                     
                         $('#txt_utiltime').text(msg.d[i].Utiletime);
                           
                      //  $('#txt_utiltime').attr('disabled','disabled');
                        $('#sp_username').text(msg.d[i].Username);
                        $('#sp_logtimr').text(msg.d[i].logtime);
                        $('#sp_logdate').text(msg.d[i].logdate);
                        $('#hdn_tt').val(msg.d[i].TT);
                         
                       
                        if(msg.d[i].pmaintenance!="" && msg.d[i].pmaintenance!=null)
                        {
                        
                            pmaintenanc=parseInt(msg.d[i].pmaintenance);
                        }
                        else
                        {
                            pmaintenanc="0";
                        }
                         if(msg.d[i].cleaning!="" && msg.d[i].cleaning!=null)
                        {
                            clean=parseInt(msg.d[i].cleaning);
                        }
                        else
                        {
                            clean="0";
                        }
                        if(msg.d[i].break1!="" && msg.d[i].break1!=null)
                        {
                            break1=parseInt(msg.d[i].break1);
                        }
                        else
                        {
                            break1="0";
                        }
                         if(msg.d[i].noplan!="" && msg.d[i].noplan!=null)
                        {
                            demand=parseInt(msg.d[i].noplan);
                        }
                        else
                        {
                            demand="0";
                        }
                         if(msg.d[i].trials!="" && msg.d[i].trials!=null)
                        {
                            trials=parseInt(msg.d[i].trials);
                        }
                        else
                        {
                            trials="0";
                        }
                        if(msg.d[i].meeitngs!="" && msg.d[i].meeitngs!=null)
                        {
                            meetings=parseInt(msg.d[i].meeitngs);
                        }
                        else
                        {
                            meetings="0";
                        }
                        if(msg.d[i].trainings!="" && msg.d[i].trainings!=null)
                        {
                            traing=parseInt(msg.d[i].trainings);
                        }
                        else
                        {
                            traing="0";
                        }
                         if(msg.d[i].plnmaintenance!="" && msg.d[i].plnmaintenance!=null)
                        {
                            plnmaintenance=parseInt(msg.d[i].plnmaintenance);
                        }
                        else
                        {
                            plnmaintenance="0";
                        }
                        getSpeedlossvalues(pmaintenanc,clean,break1,demand,trials,meetings,traing,plnmaintenance);
                        getdowntimelossentry();   
                        
                      }
                      else
                      {
                               $('#hdn_page').val(msg.d[i].page);
                               showerromessage2(msg.d[i].errormessage);

                      }
                        
                   }
                },
                error:function()
                {}
              });
}
function getfromtime(data)
{
    var fromtime=document.getElementById(data).value;
    if(fromtime=="" || fromtime==null)
    {
                       document.getElementById(data).value.focus();
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
  
       document.getElementById(data).value=hours + ":" + minute + " " + period;
    }
}

function startime()
{
    var fromt= $('#txt_speedstart').val();
    if(fromt=="" || fromt==null)
    {
         var totime=$('#txt_speedtotal').text();
         var ttime=$('#txt_speedend').val();
         $('#txt_speedstart').focus();        
    }
   
}
function startime1()
{
    var fromt= $('#txtdownstart').val();
    if(fromt=="" || fromt==null)
    {
         var totime=$('#txtdownend').val();
         var ttime=$('#txtdowntotal').val();
         $('#txtdownstart').focus();        
    }
   
}
function gettotime(from,to,total)
{
   
    var totime=document.getElementById(to).value;
    if(totime=="" || totime==null)
    {
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

       document.getElementById(to).value=hours + ":" + minute + " " + period;
       gettotaltime(from,to,total);
       
    }
}
function gettotaltime(from,to,total)
{
    var totalspeedloss='';
    var period='';
    var period1='';
    var time='';
    var fromtime= document.getElementById(from).value;
    var totime=document.getElementById(to).value;
    var fromampm=fromtime.slice(-2);
    var toampm = totime.slice(-2);
    
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
      
       
       
        if(fromampm=="AM" && toampm=="AM")
        {
            hour = e[0]-s[0]-hour_carry;
            if(hour<=9)
            {
             hour="0"+hour;
            }
            diff = hour + ":" + min;
            document.getElementById(total).value=diff;
            var speedloss=$('#txt_speedtotal').text();
        }
        if(fromampm=="PM" && toampm=="PM")
        {
            hour = e[0]-s[0]-hour_carry;
            if(hour<=9)
            {
             hour="0"+hour;
            }
            diff = hour + ":" + min;
            document.getElementById(total).value=diff;
            var speedloss=$('#txt_speedtotal').text();
        }
        if(fromampm=="AM" && toampm=="PM")
        {
            if(e[0]=="1")
            {
                e[0]=13;
            }
             if(e[0]=="2")
            {
                 e[0]=14;
            }
             if(e[0]=="3")
            {
                 e[0]=15;
            }
             if(e[0]=="4")
            {
                 e[0]=16;
            }
             if(e[0]=="5")
            {
                 e[0]=17;
            }
             if(e[0]=="6")
            {
                 e[0]=18;
            }
             if(e[0]=="7")
            {
                 e[0]=19;
            }
             if(e[0]=="8")
            {
                 e[0]=20;
            }
             if(e[0]=="9")
            {
                 e[0]=21;
            }
             if(e[0]=="10")
            {
                 e[0]=22;
            }
             if(e[0]=="11")
            {
                 e[0]=23;
            }
           
            hour = e[0]-s[0]-hour_carry;
            if(hour<=9)
            {
             hour="0"+hour;
            }
            diff = hour + ":" + min;
            document.getElementById(total).value=diff;
            var speedloss=$('#txt_speedtotal').text();
        }
        
        
  if(hour=="00" && min=="00")
  {
    $('#txt_speedtotal').text(speedloss);
  }
  else
  {
        if(hour!="00" && hour!=null && hour!="")
       {
       
            var hr=parseInt(hour)
            var hours=0;
            if(hr==1)
            {
                hours=60;
            }
            if(hr==2)
            {
                hours=120;
            }
            if(hr==3)
            {
                hours=180;
            }
            if(hr==4)
            {
                hours=240;
            }
            if(hr==5)
            {
                hours=300;
            }
            if(hr==6)
            {
                hours=360;
            }
            if(hr==7)
            {
                hours=420;
            }
            if(hr==8)
            {
                hours=480;
            }
            if(hr==9)
            {
                hours=540;
            }
            if(hr==10)
            {
                hours=600;
            }
            if(hr==11)
            {
                hours=660;
            }
            if(hr==12)
            {
                hours=720;
            }
            
  
            totalspeedloss=parseInt(speedloss)-parseInt(hours);
       }
       if(min!="00" && min!=null && min!="")
       {
       
            if(totalspeedloss!="" && totalspeedloss!=null)
            {
                totalspeedloss=parseInt(totalspeedloss)-parseInt(min);
            }
            else
            {
                totalspeedloss=parseInt(speedloss)-parseInt(min);
            }
        
       }
      
       if(parseInt(totalspeedloss)<0)
       {
            alert("Speed Loss are Lower than Zero check your Valide detail Entry");
            $('#txt_speedtotal').text('0');
       }
       else
       {
            $('#txt_speedtotal').text(totalspeedloss);
       }
  }
       
    
    }
}
$(function()
{
    $('#div_addone').click(function()
    {
       
        var premaintenance=$('#txt_pmaintenance').text();
        var clean=$('#txt_clean').text();
        var break1=$('#txt_break').text();
        var deman=$('#txt_demand').text();
        var trials=$('#txt_trails').text();
        var meetings=$('#txt_meeting').text();
        var training=$('#txt_trainig').text();
        var plnmaintenance=$('#txt_plnmaintenace').text();
        var shifthrs=$('#txt_shifthrs').text();
        var acceptqty=$('#txt_prodqty').text();
        var rejection=$('#txt_rejection').text();
        var cmm=$('#txt_cmm').val();
        var qualityissues=$('#txt_qualityissues').val();
        if(qualityissues=="" ||qualityissues==null)
        {
            qualityissues="0";
        }
        else
        {
            qualityissues=qualityissues;
        }
        var rework=$('#txt_rework').val();   
        if(rework=="" ||rework==null)
        {
            rework="0";
        }
        else
        {
            rework=rework;
        }
      
        var date=$('#txt_date').text();
        var utiletime=$('#txt_utiltime').text();
        var speedloss=$('#txt_speedtotal').text();
         var table = document.getElementById("tbl_downtimeloss");
//         var tblength=table.rows.length-1;
//         if(tblength==0)
//         {
            var res=checkeffencicy();
            if(res==true)
            {
                 $('#div_process').show();
                 $('#div_save').hide();
                var downtypeone=$('#txtdowntype').val();
                var downsone=$('#txtdownstart').val();
                var downEone=$('#txtdownend').val();
                var downtotone=$('#txtdowntotal').val();
                var remarksone=$('#txt_remarks').val();
                $.ajax({
                        url:"../Master/Default.aspx/Savedetails",
                        data:"{'pmaintenance':'"+premaintenance+"','Clean':'"+clean+"','Brak':'"+break1+"','Demand':'"+deman+"','Trials':'"+trials+"','Meetings':'"+meetings+"','Trainings':'"+training+"','Plnmaintenance':'"+plnmaintenance+"','Shifthrs':'"+shifthrs+"','Acceptqty':'"+acceptqty+"','Rejection':'"+rejection+"','CMM':'"+cmm+"','Qualityissues':'"+qualityissues+"','Rework':'"+rework+"','Downtypeone':'"+downtypeone+"','Downsone':'"+downsone+"','DownEone':'"+downEone+"','Downtotone':'"+downtotone+"','Remarksone':'"+remarksone+"','Date':'"+date+"','utiletime':'"+utiletime+"','Speedloss':'"+speedloss+"'}",
                        type:"POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg)
                        {
                   
                            if(msg.d!="F" && msg.d!=null)
                            {
                                window.top.location.href=msg.d;
                            }
                        },
                        error:function()
                        {}
                    });
//                    $.ajax({
//                    url:"../Master/Default.aspx/Movepage",
//                    data:"{}",
//                    type:"POST",
//                    contentType: "application/json; charset=utf-8",
//                    dataType: "json",
//                    success: function(msg)
//                    {
//                      window.top.location.href=msg.d;
//                    },
//                    error:function()
//                    {}
//                });  
              }
//         }
//         else
//         {
//                   var table = document.getElementById("tbl_downtimeloss");
//                   var tblength=table.rows.length-1;
//                   for(var i=1;i<table.rows.length;i++)
//                   {
//                        $('#div_process').show();
//                        $('#div_save').hide();
//                        var type=table.rows[i].cells[0].firstChild.innerHTML;
//                        var start=table.rows[i].cells[1].firstChild.innerHTML;
//                        var end=table.rows[i].cells[2].firstChild.innerHTML;
//                        var tot=table.rows[i].cells[3].firstChild.innerHTML;
//                        var remark=table.rows[i].cells[4].firstChild.innerHTML;
//                       
//                        var downtypeone=type;
//                        var downsone=start;
//                        var downEone=end;
//                        var downtotone=tot;
//                        var remarksone=remark;
//                        
//                        $.ajax({
//                                url:"../Master/Default.aspx/Savedetails",
//                                data:"{'pmaintenance':'"+premaintenance+"','Clean':'"+clean+"','Brak':'"+break1+"','Demand':'"+deman+"','Trials':'"+trials+"','Meetings':'"+meetings+"','Trainings':'"+training+"','Plnmaintenance':'"+plnmaintenance+"','Shifthrs':'"+shifthrs+"','Acceptqty':'"+acceptqty+"','Rejection':'"+rejection+"','CMM':'"+cmm+"','Qualityissues':'"+qualityissues+"','Rework':'"+rework+"','Downtypeone':'"+downtypeone+"','Downsone':'"+downsone+"','DownEone':'"+downEone+"','Downtotone':'"+downtotone+"','Remarksone':'"+remarksone+"','Date':'"+date+"','utiletime':'"+utiletime+"','Speedloss':'"+speedloss+"'}",
//                                type:"POST",
//                                contentType: "application/json; charset=utf-8",
//                                dataType: "json",
//                                success: function(msg)
//                                {
//                                    
//                                },
//                                error:function()
//                                {}
//                            }); 
//                   }
//                    window.top.location.href='../QualityGrid/QualityGrid.aspx';
//         }        
              
  
     });
});

$(function ()
{
    $('#link_productiondata1').click(function()
    {
        $.ajax({
                    url:"../Master/Default.aspx/Movepage",
                    data:"{}",
                    type:"POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg)
                    {
                      window.top.location.href=msg.d;
                    },
                    error:function()
                    {}
                });   
    });
});
function Downtimetype()
{
    var type=$('#txtdowntype').val();
    if(type=="1234567890")
    {
        $('#txtdowntype').val('Equipment Breakdown/Failure');
        $('#txtdownstart').focus();
        
    }
    if(type=="2345678901")
    {
        $('#txtdowntype').val('Unplanned Maintenance');
        $('#txtdownstart').focus();
    }
    if(type=="3456789012")
    {
        $('#txtdowntype').val('Set Up Change Over');
        $('#txtdownstart').focus();
    }
    if(type=="4567890123")
    {
        $('#txtdowntype').val('Material Shortage/Delay');
        $('#txtdownstart').focus();
    }
    if(type=="5678901234")
    {
        $('#txtdowntype').val('Operator Shortage');
        $('#txtdownstart').focus();
        
    }
    if(type=="6789012345")
    {
        $('#txtdowntype').val('Not Planned Manuf Engg Trails');
        $('#txtdownstart').focus();
        
    }
    
}
function Speedlosstype()
{
    var type=$('#txt_speedtype').val();
    if(type=="1234567890")
    {
        $('#txt_speedtype').val('Minor Breakdown');
        $('#txt_speedstart').focus();
    }
    if(type=="2345678901")
    {
        $('#txt_speedtype').val('Due To Bottle Neck Down');
        $('#txt_speedstart').focus();
    }
    
}
function checkeffencicy()
{
    if(!validatecmm())return false
    if(!validatedowntype())return false
    if(!validate_fromtime())return false
    if(!validate_downend())return false
    
    return true;
}

function validatecmm()
{
    var cmm=$('#txt_cmm').val();
    if(cmm=="" || cmm==null)
    {
        document.getElementById("txt_cmm").className="error";
        $('#txt_cmm').focus();
        return false;
    }
    else
    {
        document.getElementById("txt_cmm").className="";
        return true;
    }
}
//1
function validatedowntype()
{

    var type=$('#txtdowntype').val();
    
    if(type=="" || type==null)
    {
    
          document.getElementById("txtdowntype").className="error";
         $('#txtdowntype').focus();
            return false;
    }
    else
    {
        document.getElementById("txtdowntype").className="";
        return true;
    }
}
function validate_fromtime()
{
        var type1=$('#txtdowntype').val();
        var fromtime=$('#txtdownstart').val();
      
        if(type1!="" || type1!=null)
        {
             if(fromtime=="" || fromtime==null)
            {
                 document.getElementById("txtdownstart").className="error";
                $('#txtdownstart').focus();
                 return false;
            }
            else
            {
                document.getElementById("txtdownstart").className="";
                 return true;
            }
         
}
        else
            {
                 return true;
            }
    
}

function validate_speedend()
{   
    var spstart=$('#txt_speedstart').val();

    var spend=$('#txt_speedend').val();
    var stype=$('#txt_speedtype').val();
   
        if(spstart!="" && spstart!=null)
        {
            if(spend=="" || spend==null || stype=="" || stype==null)
            {
                $('#txt_speedend').addClass('error');
                $('#txt_speedtype').addClass('error');
                if(spend!="" && spend!=null)
                {
                    $('#txt_speedend').removeClass('error');
                }
                 if(stype!="" && stype!=null)
                {
                    $('#txt_speedtype').removeClass('error');
                }
                
            }
            else
            {
                 $('#txt_speedend').removeClass('error');
                $('#txt_speedtype').removeClass('error');
                return true;
            }
            
        }
        else
        {
            return true;
        }
    
   
}
function validate_downend()
{
     var dstart=$('#txtdownstart').val();

    var dend=$('#txtdownend').val();
    var dtype=$('#txtdowntype').val();
       
        if(dstart!="" && dstart!=null)
        {
            if(dend=="" || dend==null || dtype=="" || dtype==null)
            {
                 $('#txtdownend').addClass('error');
                $('#txtdowntype').addClass('error');
                if(dend!="" && dend!=null)
                {
                    $('#txtdownend').removeClass('error');
                }
                 if(dtype!="" && dtype!=null)
                {
                    $('#txtdowntype').removeClass('error');
                }
               
               
            }
            else
            {
                $('#txtdownend').removeClass('error');
                $('#txtdowntype').removeClass('error');
                return true;
            }
            
        }
        else
        {
            return true;
        }
    
}

$(function()
{
    $('#div_closepage').click(function()
    {
//       var url=$('#hdn_page').val();
//        var url="../Productions/DownTimeLoss.htm";
//        window.top.location.href=url;
        hideLayer();
    });
});
//$(function()
//{
//    $('#txt_cmm').blur(function()
//    {
//        var cmm= $('#txt_cmm').val();
//        if(cmm!="" && cmm!=null)
//        {
//            var speedloss=$('#txt_speedtotal').text();
//            var values=(parseInt(speedloss))-(parseInt(cmm));
//            $('#txt_speedtotal').text(values)
//        }
//       
//        
//    });
//});

//$(function()
//{
//    $('#txt_qualityissues').blur(function()
//    {
//        var cmm= $('#txt_qualityissues').val();
//        if(cmm!="" && cmm!=null)
//        {
//            var speedloss=$('#txt_speedtotal').text();
//            var values=(parseInt(speedloss))-(parseInt(cmm));
//            $('#txt_speedtotal').text(values)
//        }
//        
//    });
//});
//$(function()
//{
//    $('#txt_rework').blur(function()
//    {
//            var cmm= $('#txt_rework').val();
//            if(cmm!="" && cmm!=null)
//            {
//                var speedloss=$('#txt_speedtotal').text();
//                var values=(parseInt(speedloss))-(parseInt(cmm));
//                $('#txt_speedtotal').text(values)
//            }
//      
//        
//    });
//});
//1
function validateaddone()
{
    if(!checktypeone())return false
    if(!checkstart())return false
    if(!checkend())return false
    //if(!checkremark())return false
    return true;
}
function checktypeone()
{
    var type=$('#txtdowntype').val();
    if(type=="" || type==null)
    {
        $('#txtdowntype').addClass('error');
        return false;
    }
    else
    {
       $('#txtdowntype').removeClass('error').addClass('');
        return true;
    }
}
function checkstart()
{
    var start=$('#txtdownstart').val();
    if(start=="" || start==null)
    {
        $('#txtdownstart').addClass('error');
        return false;
    }
    else
    {
       $('#txtdownstart').removeClass('error').addClass('');
        return true;
    }
}
function checkend()
{
    var end=$('#txtdownend').val();
    if(end=="" || end==null)
    {
        $('#txtdownend').addClass('error');
        return false;
    }
    else
    {
       $('#txtdownend').removeClass('error').addClass('');
        return true;
    }
}
function checkremark()
{
    var remark=$('#txt_remarks').val();
    if(remark=="" || remark==null)
    {
        $('#txt_remarks').addClass('error');
        return false;
    }
    else
    {
       $('#txt_remarks').removeClass('error').addClass('');
        return true;
    }
}

$(function()
{
    $('#div_addone').click(function()
    {
        var res=validateaddone();
        if(res==true)
        {
            $('#div_down').show();
            var type = document.getElementById("txtdowntype");
            var start_time = document.getElementById("txtdownstart");
            var end_time = document.getElementById("txtdownend");
            var total = document.getElementById("txtdowntotal");
            var remark = document.getElementById("txt_remarks");
            var table = document.getElementById("tbl_downtimeloss");
         
            var rowCount = table.rows.length;
            var row = table.insertRow(rowCount);
         
            row.insertCell(0).innerHTML='<span id="spn_type">'+type.value+'</span>';
            row.insertCell(1).innerHTML= '<span id="spn_start">'+start_time.value+'</span>';
            row.insertCell(2).innerHTML= '<span id="spn_end">'+end_time.value+'</span>';
            row.insertCell(3).innerHTML= '<span id="spn_total">'+total.value+'</span>';
            row.insertCell(4).innerHTML= '<span id="spn_remark">'+remark.value+'</span>';
            
            $("#txtdowntype").val('');
            $("#txtdownstart").val('');
            $("#txtdownend").val('');
            $("#txtdowntotal").val('');
            $("#txt_remarks").val('');
            $("#tbl_downtimeloss").val('');
        }
    });
});

function getdowntimelossentry()
{
    var partno= $("#hdn_part").val();
    var process= $("#hdn_process").val();
    var machinename=$('#hdn_machine').val();
    var pidno=$('#hdn_pidno').val();
    var shift=$('#hdn_shift').val();
    var unit =$('#hdn_unit').val();
      $.ajax({
            url:"../Master/Default.aspx/get_downtime",
            data:"{'part':'"+partno+"','pid':'"+pidno+"','shift':'"+shift+"','operation':'"+process+"','Machine':'"+machinename+"','Unit':'"+unit+"'}",
            type:"POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg)
            {
                if(msg.d!=null && msg.d!="")
                {
                
                    for(var i=0;i<msg.d.length;i++)
                    {
                        var table = document.getElementById("tbl_downtimeloss");
             
                        var rowCount = table.rows.length;
                        var row = table.insertRow(rowCount);
                        row.insertCell(0).innerHTML='<span id="spn_type">'+msg.d[i].types+'</span>';
                        row.insertCell(1).innerHTML= '<span id="spn_start">'+msg.d[i].start_time+'</span>';
                        row.insertCell(2).innerHTML= '<span id="spn_end">'+msg.d[i].end_time+'</span>';
                        row.insertCell(3).innerHTML= '<span id="spn_total">'+msg.d[i].total+'</span>';
                        row.insertCell(4).innerHTML= '<span id="spn_remark">'+msg.d[i].Remarks+'</span>';
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
//$(function()
//{
//    $('#link_dwntime1').click(function()
//    {
//         window.top.location.href="../Productions/DownTimeLoss.htm";
//    });
//});   

