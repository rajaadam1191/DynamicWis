$('#Slct_machine').live('keydown', function(e) {
    if (e.keyCode === 9) {
        e.preventDefault();
        // do work
//       document.getElementById("btn_submit").focus();
//       document.getElementById("btn_submit").scrollIntoView();
var ele = document.getElementById("btn_submit");
   ele.scrollIntoView();
   ele.tabIndex = -1;
   ele.focus();
    }
});

$('#btn_submit').live('keydown', function(event) {
    if(event.keyCode == 13){
        $("#btn_submit").click();
    }
});


function checkpidvalue()
{
 var pidno = $('#txt_pidno').val();
 if(pidno.length<13)
 {
 var str=pidno;
 }
 else{
  var str = pidno.substring(0, pidno.length-3);
 }
  $('#diverror').hide();
   $.ajax({
            url:"Master/Default.aspx/Get_Autoprtno",
            data:"{'PID':'"+str+"'}",
            type:"POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg)
            {
              $("input[id$='txt_partno']").val(msg.d);
              //$('#ddl_partno').focus();
//              loadhomepartno();
//              getdept();
              $('#searchbox').focus();
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
                url:"Master/Default.aspx/getpartnumber",
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
                   //GetProcess();
                },
                error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
        });
});   

function loadhomepartno()
{
var comma=null;
var part=[];
$.ajax({
        url:"Master/Default.aspx/getpartnumber",
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
           GetProcess();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
    });
}
function loadhomepartnoempty()
{
var comma=null;
var part=[];
var partno=$("#ddl_partno").val();
if(partno =="")
{
    $.ajax({
            url:"Master/Default.aspx/getpartnumber",
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
               GetProcessempty();
            },
            error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
        });
   }
}
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
//if(unt != "" && unt !="0")
//{
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
            error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
          });
//    }
}

function GetProcessempty()
{
var comma=null;
var part=[];
var opt = $("#ddl_opt").val();
if(opt == "")
{
    $.ajax({
                url:"Master/Default.aspx/Get_prtprocess",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("#ddl_opt").get(0).options.length = 0;
                    $("#ddl_opt").get(0).options[0] = new Option("-Select-", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            if(comma[count]=="OP1")
                            {
                                $("#ddl_opt").get(0).options[$("#ddl_opt").get(0).options.length] = new Option(comma[count], "1");                            
                            }
                            else if(comma[count]=="OP2")
                            {
                                $("#ddl_opt").get(0).options[$("#ddl_opt").get(0).options.length] = new Option(comma[count], "2");
                            }
                            else
                            {
                                $("#ddl_opt").get(0).options[$("#ddl_opt").get(0).options.length] = new Option(comma[count], comma[count]);
                            }
                        }
                    }
                    part=null;
                    comma=null;
                     var unit=$('#ddl_unit').val();
                     if(unit!=null|| unit!="0" || unit!="-Select-")
                     {
                        $('#ddl_unit').val(0);
                     }
                },
                error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
        });
   }
}            
function GetProcess()
{
var comma=null;
var part=[];
    $.ajax({
                url:"Master/Default.aspx/Get_prtprocess",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("#ddl_opt").get(0).options.length = 0;
                    $("#ddl_opt").get(0).options[0] = new Option("-Select-", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            if(comma[count]=="OP1")
                            {
                                $("#ddl_opt").get(0).options[$("#ddl_opt").get(0).options.length] = new Option(comma[count], "1");                            
                            }
                            else if(comma[count]=="OP2")
                            {
                                $("#ddl_opt").get(0).options[$("#ddl_opt").get(0).options.length] = new Option(comma[count], "2");
                            }
                            else
                            {
                                $("#ddl_opt").get(0).options[$("#ddl_opt").get(0).options.length] = new Option(comma[count], comma[count]);
                            }
                        }
                    }
                    part=null;
                    comma=null;
                     var unit=$('#ddl_unit').val();
                     if(unit!=null|| unit!="0" || unit!="-Select-")
                     {
                        $('#ddl_unit').val(0);
                     }
                },
                error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
        });
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
                error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
              });
              }
              
function getfixture()
{
              var partno=$('#ddl_partno').val();

        $.ajax({
                url:"Master/Default.aspx/getfixtureno",
                data:"{'Partno':'"+partno+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    $("#Slct_fixture").get(0).options.length = 0;
                    $("#Slct_fixture").get(0).options[0] = new Option("-Select-", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("#Slct_fixture").get(0).options[$("#Slct_fixture").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    
              },
                error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
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
                error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
              });
              }
              
            $(function()
            {
                $('#spn_closehpop').click(function()
                {
                     var modal = document.getElementById('myModal');
                     modal.style.display = "none";
                });
            });  
            
 $(function()
 {
 //////
    $('#btn_submit').click(function()
    {   
   // //
        var result=checksubmit();
        if(result==true)
        {
             var pidno=$('#txt_pidno').val();
             var partno=$('#ddl_partno').val();
              var optn=$('#ddl_opt').val();
              var mchn=$('#Slct_machine').val();
              var process=$('#ddl_process').val();
              $('#hdn_process').val(optn);
              var depat=$('#ddl_dept').val();
              var unit=$('#ddl_unit').val();
              //var fixture=$('#Slct_fixture').val();
              $.ajax({
                url:"Master/Default.aspx/UserAuthentication",
                data:"{'PID':'"+pidno+"','Partno':'"+partno+"','Operation':'"+optn+"','machine':'"+mchn+"','Process':'"+process+"','Dept':'"+depat+"','Unit':'"+unit+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                
                success: function(msg)
                {
                   if(msg.d=="S")
                   {
                      $.ajax({
                                url:"Master/Default.aspx/CheckDyn",
                                data:"{'Partno':'"+partno+"','Operation':'"+optn+"','Unit':'"+unit+"','Cell':'"+depat+"'}",
                                type:"POST",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function(msg)
                                {
                                   if(msg.d=="S")
                                   {
                                        window.top.location.href="DYNSheets/QualitySheet.aspx";
                                   }
                                   else
                                   {
                                         var op;
                                         $('#spn_msg').text('Quality Sheet Does not exist for');
                                         if(optn=='1' || optn=='2')
                                         {
                                            op='Operation '+ optn;
                                         }
                                         else
                                         {
                                            op=optn;
                                         }
                                         $('#spn_parthome').text(partno +' [ '+op+' ]');
                                         var modal = document.getElementById('myModal');
                                         modal.style.display = "block";
                                     }
                                 },
                                error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
                              });
                         
                   }
                   else{
                   }
                },
                error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);}
              });
              
        }
        
    });
 });
 
function checksubmit()
{
  //if(!validate_pidno()) return false
  if(!validate_partno()) return false 
    if(!validate_optn()) return false
    if(!validate_unit()) return false 
    if(!validate_dept()) return false
    if(!validate_mchn()) return false 
    //if(!validate_fix()) return false 
    if(!validate_process())return false
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
 
 var partno=$('#ddl_partno').val();
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
    var partno=$('#ddl_partno').val();
    if((partno=="A17724Q" && optn=="1") || (partno=="A17724Q" && optn=="Polishing"))
    {
        $('#tr_process').slideDown(100);
    }
    else
    {
        $('#tr_process').slideUp(100);
    }
    
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
  function  validate_fix()
 {
 var fix=$('#Slct_fixture').val();
 if(fix==null|| fix=="0")
 {
 //$('#ddl_dept').focus();
 $('#diverror').show();
 $('#spn_error').text('Please Select Fixture No');
 return false;
 }
 else
 {
  $('#diverror').hide();
  return true;
  }
 } 
 
 function validate_process()
 {
    if ($('#tr_process').css('display') == 'none')
    {
        return true;
    }
    else
    {
        var pr=$('#ddl_process').val();
        if(pr=="0")
        {
             $('#diverror').show();
            $('#spn_error').text('Please Select Process');
            return false;
        }
        else
        {
            $('#diverror').show();
            return true;
        }
    }
 }
 
 