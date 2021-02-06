
function checksubmit()
{
    //if(!validate_pidno()) return false
    if(!validate_partno()) return false 
    if(!validate_optn()) return false
    if(!validate_unit()) return false 
    if(!validate_dept()) return false
    if(!validate_mchn()) return false 

    return true;
 }   
  function validate_pidno()
  {
  var pidno=$('#txt_pidno').val();
  if(pidno==null|| pidno =="")
  {
//  $('#txt_pidno').focus();
  $('#diverror').show();
  $('#spn_error').text('Please Enter PidNo');
  return false;
  }
  else
  {
  $('#diverror').hide();
  return true;
  }
 }
 function validate_partno()
 {
 
 var partno=$('#txt_partno').val();
 if(partno==null || partno=="0")
 {
 //$('#ddl_partno').focus();
 $('#diverror').show();
 $('#spn_error').text('Please Select Part No');
 return false;
 }
 else
 {
  $('#diverror').hide();
  return true;
  }
 }
 
  function validate_optn()
 {
 var optn=$('#ddl_opt').val();
 if(optn==null|| optn=="0")
 {
 //$('#ddl_opt').focus();
 $('#diverror').show();
 $('#spn_error').text('Please Select Operation');
 return false;
 }
 else
 {
  $('#diverror').hide();
  return true;
  }
 } 
  function  validate_unit()
 {
 var unit=$('#ddl_unit').val();
 if(unit==null|| unit=="0" || unit=="-Select-")
 {
 //$('#ddl_unit').focus();
 $('#diverror').show();
 $('#spn_error').text('Please Select Unit');
 return false;
 }
 else
 {
  $('#diverror').hide();
  return true;
  }
 }

 function  validate_dept()
 {
 var dept=$('#ddl_dept').val();
 if(dept==null|| dept=="0")
 {
 //$('#ddl_dept').focus();
 $('#diverror').show();
 $('#spn_error').text('Please Select Department');
 return false;
 }
 else
 {
  $('#diverror').hide();
  return true;
  }
 } 
 function  validate_mchn()
 {
 var mchn=$('#Slct_machine').val();
 if(mchn==null|| mchn=="0")
 {
 //$('#ddl_dept').focus();
 $('#diverror').show();
 $('#spn_error').text('Please Select Machine');
 return false;
 }
 else
 {
  $('#diverror').hide();
  return true;
  }
 } 
 
 $(function()
 {
    $('#btn_submit').click(function()
    {   
        var result=checksubmit();
        if(result==true)
        {
             var pidno=$('#txt_pidno').val();
             var partno=$('#txt_partno').val();
              var optn=$('#ddl_opt').val();
              var mchn=$('#Slct_machine').val();
              $.ajax({
                url:"Master/Default.aspx/UserAuthentication",
               // data:"{}",
                data:"{'PID':'"+pidno+"','Partno':'"+partno+"','Operation':'"+optn+"','machine':'"+mchn+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                   if(msg.d=="S")
                   {
                         //Q
                        if (partno == "A17724Q" && optn == "1")
                        {
                           
                           window.top.location.href="QualityGrid/QualityGrid.aspx";
                        }
                        if (partno == "A17724Q" && optn == "2")
                        {
                            window.top.location.href="QualityGrid/opt2QSheetA17724Q.aspx";
                        }
                        if (partno == "A17724Q" && optn == "Polishing")
                        {
                            window.top.location.href="QualityGrid/polishing24Q.aspx";
                        }
                        if (partno == "A17724Q" && optn == "Lapping")
                        {
                            window.top.location.href="QualityGrid/lapping24Q.aspx";
                        }
                        //J
                        if (partno == "A22916J" && optn == "1")
                        {
                            window.top.location.href="QualityGrid/QSA22916J.aspx";
                        }
                        if (partno == "A22916J" && optn == "2")
                        {
                            window.top.location.href="QualityGrid/opt2QSheetA22916J.aspx";
                        }
                        if (partno == "A22916J" && optn == "Polishing")
                        {
                            window.top.location.href="QualityGrid/polishingA22916J.aspx";
                        }
                         if (partno == "A22916J" && optn == "Lapping")
                        {
                            window.top.location.href="QualityGrid/lapping24Q.aspx";
                        }
                        //U
                        if (partno == "A44983U" && optn == "1")
                        {
                            window.top.location.href="QualityGrid/qualitysheetA44983u.aspx";
                        }
                        if (partno == "A44983U" && optn == "Polishing")
                        {
                            window.top.location.href="QualityGrid/polishingA44983U.aspx";
                        }
                         if (partno == "A44983U" && optn == "Lapping")
                        {
                            window.top.location.href="QualityGrid/lapping24Q.aspx";
                        }
                        //C
                        if (partno == "A32271C" && optn == "1")
                        {
                            window.top.location.href="QualityGrid/QualitySheetA32271C.aspx";
                        }
                        if (partno == "A32271C" && optn == "Polishing")
                        {
                            window.top.location.href="QualityGrid/polishingA32271C.aspx";
                        }
                         if (partno == "A32271C" && optn == "Lapping")
                        {
                            window.top.location.href="QualityGrid/lapping24Q.aspx";
                        }
                        //N
                        if (partno == "A44908N" && optn == "1")
                        {
                            window.top.location.href="QualityGrid/QualitySheetA44908N.aspx";
                        }
                        if (partno == "A44908N" && optn == "Polishing")
                        {
                            window.top.location.href="QualityGrid/polishingA44908N.aspx";
                        }
                         if (partno == "A44908N" && optn == "Lapping")
                        {
                            window.top.location.href="QualityGrid/lapping24Q.aspx";
                        }
                   }
                   else{
                   }
                },
                error:function()
                {}
              });
              
        }
        
    });
 });
//function checkpidno()
//{
//    if(!checkpidvalue()) return false
// }

function checkpidvalue()
{
alert("k");
  var pidno=$('#txt_pidno').val();
    $.ajax({
                
            
                url:"Master/Default.aspx/Get_Autoprtno",
                data:"{'PID':'"+pidno+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                alert
                 },
                error:function()
                {}
        });
}

$(document).ready(function()
{

var comma=null;
var part=[];
    $.ajax({
                url:"Master/Default.aspx/Get_prtno",
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
});   
    
function validate_logn()
{
 var pid=$('#txt_pidno').val();
 if(pid!=null || pid!="0" ||pid!="0" )
 {
 $('#ddl_partno').focus();
 }
}
    

function getdept()
{
              var unt=$('#ddl_unit').val();

        $.ajax({
                url:"Master/Default.aspx/getdepartment",
                data:"{'unit':'"+unt+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    $("#ddl_dept").get(0).options.length = 0;
                    $("#ddl_dept").get(0).options[0] = new Option("-Select-", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("#ddl_dept").get(0).options[$("#ddl_dept").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
              }
              
              
 function getmachine()
{
              var dept=$('#ddl_dept').val();

        $.ajax({
                url:"Master/Default.aspx/getmachinename",
                data:"{'dept':'"+dept+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    $("#Slct_machine").get(0).options.length = 0;
                    $("#Slct_machine").get(0).options[0] = new Option("-Select-", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("#Slct_machine").get(0).options[$("#Slct_machine").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
              }