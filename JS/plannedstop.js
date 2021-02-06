function getplannedstop(data)
{
 $("input[id$='hdn_planid']").val(data);
  $("div[id$='div_save']").hide();
   $("div[id$='div_update']").show();
     $.ajax({
                url:"../Master/Default.aspx/Getplannedstop",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    for(var i=0;i<msg.d.length;i++)
                    {
                         $("select[id$='ddl_partno']").val(msg.d[i].partno);
                         $("select[id$='ddl_process']").val(msg.d[i].Process);
                          $("input[id$='txt_pmaintenance']").val(msg.d[i].pmaintenance);
                         $("input[id$='txt_cleaning']").val(msg.d[i].cleaning);
                         $("input[id$='txt_break']").val(msg.d[i].break1);
                          $("input[id$='txt_demand']").val(msg.d[i].noplan);
                         $("input[id$='txt_trial']").val(msg.d[i].trials);
                          $("input[id$='txt_meetings']").val(msg.d[i].meeitngs);
                         $("input[id$='txt_traings']").val(msg.d[i].trainings);
                          $("input[id$='txt_planedmaintenance']").val(msg.d[i].plnmaintenance);

                    }
                },
                error:function()
                {}
              });
}
function deleteplannedstop(data)
{
    var con=window.confirm('Are You Sure Want To Delete This Registered Details');
    if(con==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/Deleteplaned",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        alert("Record Deleted Successfully");
                        window.top.location.href="../Master/PlannedStopEntry.aspx";
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

function deletecLABOREFFICICENCY(data)
{
    var con=window.confirm('Are You Sure Want To Delete This Registered Details');
    if(con==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/Deletelaboreff",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        alert("Record Deleted Successfully");
                        window.top.location.href="../Master/LaborEfficiency.aspx";
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
function validate_plannedentry()
{
if(!validate_Pprtno())return false
if(!validate_Pprocess())return false
if(!validate_Pmiantenance())return false
if(!validate_Pcleaning())return false
if(!validate_Pbreak())return false
if(!validate_Pnoplan())return false
if(!validate_Ptrials())return false
if(!validate_Pmeetings())return false
if(!validate_Ptrainigs())return false
if(!validate_Planmaintenace())return false
}
function validate_Pprtno()
{
    var prtno=$("select[id$='ddl_partno']").val();
  
    if(prtno=="0" || prtno=="-Select-")
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Select Part No');
        //$("select[id$='ddl_partno']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Pprocess()
{
     var process=$("select[id$='ddl_process']").val();
    if(process=="0" || process=="-Select-")
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Select Process');
        //$("select[id$='ddl_process']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}

function validate_Pmiantenance()
{
    var pmaintenance=$("input[id$='txt_pmaintenance']").val();
    if(pmaintenance=="" || pmaintenance==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Enter Preventive Maintenance Time');
       // $("input[id$='txt_fixed_data']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Pcleaning()
{
     var cleaing=$("input[id$='txt_cleaning']").val();
    if(cleaing=="" || cleaing==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Enter Cleaning Time');
      //  $("input[id$='txt_lunchtime']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Pbreak()
{
     var break1=$("input[id$='txt_break']").val();
    if(break1=="" || break1==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Enter Break Time');
       // $("input[id$='txt_teatime']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}


function validate_Pnoplan()
{
     var demand=$("input[id$='txt_demand']").val();
    if(demand=="" || demand==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Enter No Plan/Demand Time');
       // $("input[id$='txt_plan']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Ptrials()
{
     var trial=$("input[id$='txt_trial']").val();
    if(trial=="" || trial==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Enter Trial Time');
       // $("input[id$='txt_maintenance']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Pmeetings()
{
     var meeitng=$("input[id$='txt_meetings']").val();
    if(meeitng=="" || meeitng==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Enter Meeting Time');
       // $("input[id$='txt_manuf']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}

function validate_Ptrainigs()
{
     var traings=$("input[id$='txt_traings']").val();
    if(traings=="" || traings==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Enter Trainings Time');
       // $("input[id$='txt_meeting']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Planmaintenace()
{
     var planmainten=$("input[id$='txt_planedmaintenance']").val();
    if(planmainten=="" || planmainten==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spn_error']").text('Please Enter Planned Maintenance Time');
       // $("input[id$='txt_meeting']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}