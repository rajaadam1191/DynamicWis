//function machine_validate()
//{

// if(!validate_rptPartno())return false 
// if(!validate_rptProcess()) return false 
// if(!validate_rptmcshift()) return false 
//  if(!validate_rptunit()) return false 
// if(!checkfromdate())return false
// if(!checktodate())return false
//}
//function validate_rptPartno()
// {

// var part=$("select[id$='ddl_partno']").val();
// if(part==null||part=="0"||part=="-Select-")
// {
//      $("div[id$='diverror']").show();
//        $("span[id$='spn_error']").text('Please Select Part NO');
//        $("select[id$='ddl_partno']").focus()
//     return false;
// }
// else
// {
// $("div[id$='diverror']").hide();
//      return true;
//  }
// }
// function validate_rptProcess()
// {
// var process=$("select[id$='ddl_process']").val();

// if(process==null||process=="0"||process=="-Select-")
// {
//      $("div[id$='diverror']").show();
//        $("span[id$='spn_error']").text('Please Select Process');
//        $("select[id$='ddl_process']").focus()
//     return false;
// }
// else
// {
// $("div[id$='diverror']").hide();
//      return true;
//  }
// }

//function validate_rptmcshift()
//{
// var shift=$("select[id$='ddl_shift']").val();
// 
// if(shift==null || shift=="0"|| shift=="-Select-")
// {
// $("div[id$='diverror']").show();
//        $("span[id$='spn_error']").text('Please Select Shift');
//        $("select[id$='ddl_shift']").focus()
//    
//     return false;
// }
// else
// {
//  $("div[id$='diverror']").hide();

//      return true;
//  }
//}
//function validate_rptunit()
//{
//  var mach=$("select[id$='ddl_unit']").val();
// if(mach==null || mach=="0"|| mach=="-Select-")
// {
//  $("div[id$='diverror']").show();
//        $("span[id$='spn_error']").text('Please Select unit');
//        $("select[id$='ddl_unit']").focus()
//  
//     return false;
// }
// else
// {
//   $("div[id$='diverror']").hide();
//      return true;
//  }
//}
//function checkfromdate()
//{

//  var dt=$("input[id$='txtt_fromdate']").val();
// 
//    if(dt=="" || dt==null)
//    {
//    $("div[id$='diverror']").show();
//        $("span[id$='spn_error']").text('Please Select From Date');
//        $("input[id$='txtt_fromdate']").focus()
//      
//       return false;
// }
// else
// {
//    $("div[id$='diverror']").hide();
//      return true;
//  }
//}
//function checktodate()
//{

//  var dt=$("input[id$='txtt_todate']").val();
// 
//    if(dt=="" || dt==null)
//    {
//    $("div[id$='diverror']").show();
//        $("span[id$='spn_error']").text('Please Select To Date');
//        $("input[id$='txtt_todate']").focus()
//       
//       return false;
// }
// else
// {
//        $("div[id$='diverror']").hide();

//      return true;
//  }
//}


 function getmachine_mcrpt()
{
              var unit_Mchn_rpt=$("select[id$='ddl_unit'] ").val();
          
        $.ajax({
                url:"../Master/Default.aspx/getmachinename_MC_RPT",
                data:"{'unit_Mchn_rpt':'"+unit_Mchn_rpt+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    $("select[id$='Slct_machine_rpt']").get(0).options.length = 0;
                    $("select[id$='Slct_machine_rpt']").get(0).options[0] = new Option("-Select-", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='Slct_machine_rpt']").get(0).options[$("select[id$='Slct_machine_rpt']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
              }