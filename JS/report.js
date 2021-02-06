function validatereports()
{
    if(!validate_types())return false
    return true;
}
function validate_types()
{    
     var type=$("select[id$='ddl_type']").val();
     if(type=="" || type==null || type=="0")
     {
        $("div[id$='div_errorr']").show();
        $("span[id$='spnerror']").text('Please Select Type');
        $("select[id$='ddl_type']").focus();
        return false;
     }
     else
     {
       if(type=="3")
       {
       var unit=$("select[id$='ddl_unit_QC_chart']").val();
      var mchn=$("select[id$='Slct_machine_QC_chart']").val();
         var part=$("select[id$='ddl_partno']").val();
            var process=$("select[id$='ddl_process']").val();
             var shift=$("select[id$='ddl_shift']").val();
             if(unit=="-Select-"||unit=="0" )
             {
             $("div[id$='div_errorr']").show();
            $("span[id$='spnerror']").text('Please Select Unit');
            $("select[id$='ddl_unit_QC_chart']").focus();
             return false;
             }
             if(mchn=="-Select-" || mchn=="0")
             {
       
             $("div[id$='div_errorr']").show();
            $("span[id$='spnerror']").text('Please Select Machine Name');
            $("select[id$='Slct_machine_QC_chart']").focus();
             return false;
            }
            if(part=="-Select-")
            {
                 $("div[id$='div_errorr']").show();
            $("span[id$='spnerror']").text('Please Select Part No');
            $("select[id$='ddl_partno']").focus();
             return false;
            }
            if(process=="-Select-")
            {
            $("div[id$='div_errorr']").show();
            $("span[id$='spnerror']").text('Please Select Process');
            $("select[id$='ddl_process']").focus();
             return false;
            }
//             if(shift=="0")
//            {
//                 alert("Select shift");
//                return false;
//            }
            else{
            return true;
            }
       }
       else
       {
        return true;
       }
     }
}
function getmachine()
{
var dept=$('#Slct_Cell_QC').val();

$.ajax({
        url:"Master/Default.aspx/getmachinename",
        data:"{'dept':'"+dept+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
       
            $("#Slct_machine_QC").get(0).options.length = 0;
            $("#Slct_machine_QC").get(0).options[0] = new Option("-Select-", "0");
            part=msg.d;
            comma=part.split(",");
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    $("#Slct_machine_QC").get(0).options[$("#Slct_machine_QC").get(0).options.length] = new Option(comma[count], comma[count]);
                }
            }
            part=null;
            comma=null;
            
      },
        error:function()
        {}
      });
}
function movepages()
{
    var res=validatereports();
    if(res==true)
    {
        var type=$("select[id$='ddl_type']").val();
        var part=$("select[id$='ddl_partno']").val();
        var process=$("select[id$='ddl_process']").val();
        var from=$("input[id$='txt_fromdate']").val();
        var to=$("input[id$='txt_todate']").val();
        var shift=$("select[id$='ddl_shift']").val();
      var mchn=$("select[id$='Slct_machine_QC_chart']").val();
      //$.session.set("mchn", $("select[id$='Slct_machine_QC_chart']").val());
     // var machine= "<%= Session["mchn"]%>";
    
        var unit=$("select[id$='ddl_unit_QC_chart']").val();
       
        if(type=="1")
        {
            window.top.location.href='DMTRptFrm.aspx?Type='+type+'&Partno='+part+'&Operation='+process+'&fromdate='+from+'&todate='+to+'&Shift='+shift+'';
        }
         if(type=="2")
        {   
            window.top.location.href='EfficiencyReports.aspx?Type='+type+'&Partno='+part+'&Operation='+process+'&fromdate='+from+'&todate='+to+'&Shift='+shift+'';
        }
         if(type=="3")
        {
            window.top.location.href='../QualityGrid/ViewQChart.aspx?Type='+type+'&Partno='+part+'&Operation='+process+'&fromdate='+from+'&todate='+to+'&Shift='+shift+'&mchn='+mchn+'&unit='+unit+'';
        }
    }
}