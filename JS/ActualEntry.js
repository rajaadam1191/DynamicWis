function validate_Actualentry()
{
if(!validate_Aprtno())return false
if(!validate_Aprocess())return false
if(!validate_Ashift())return false
if(!validate_AFixedtime())return false
//if(!validate_Aprdqty())return false

}
function validate_Aprtno()
{
    var prtno=$("select[id$='ddl_partno']").val();
    if(prtno=="0" || prtno=="-Select-")
    {
        $("div[id$='div_error']").show();
        $("span[id$='spnerror']").text('Please Select Part No');
        //$("select[id$='ddl_partno']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Aprocess()
{
     var process=$("select[id$='ddl_process']").val();
    if(process=="0" || process=="-Select-")
    {
        $("div[id$='div_error']").show();
        $("span[id$='spnerror']").text('Please Select Process');
        //$("select[id$='ddl_process']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Ashift()
{
     var shift1=$("select[id$='ddl_shift']").val();
    if(shift1=="0" || shift1=="-Select-")
    {
        $("div[id$='div_error']").show();
        $("span[id$='spnerror']").text('Please Select Shift');
      //  $("select[id$='ddl_shift']").focus();
        return false;
        
    }
    else
    {   
        var shift11=$("select[id$='ddl_shift']").val();
        if(shift11=="A" ||shift11=="B" ||shift11=="C" ||shift11=="G")
        {
            $("input[id$='txt_fixedtime']").val('480');
        }
        if(shift11=="A1" ||shift11=="B1")
        {
            $("input[id$='txt_fixedtime']").val('720')
        }
        $("div[id$='ddl_shift']").hide();
        return true;
    }
}
function validate_AFixedtime()
{
    var Setup=$("input[id$='txt_fixedtime']").val();
    if(Setup=="" || Setup==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spnerror']").text('Please Enter Fixed Time');
       // $("input[id$='txt_fixed_data']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function validate_Aprdqty()
{
     var Lunch=$("input[id$='txt_prdquty']").val();
    if(Lunch=="" || Lunch==null)
    {
        $("div[id$='div_error']").show();
        $("span[id$='spnerror']").text('Please Enter Produced Quantity');
      //  $("input[id$='txt_lunchtime']").focus();
        return false;
        
    }
    else
    {   
        $("div[id$='div_error']").hide();
        return true;
    }
}
function getactualdata(data)
{

 $("input[id$='hdn_actualid']").val(data);
  $("div[id$='div_save']").hide();
   $("div[id$='div_update']").show();
     $.ajax({
                url:"../Master/Default.aspx/getactual_timevalues",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    for(var i=0;i<msg.d.length;i++)
                    {
                        
                         $("select[id$='ddl_partno']").val(msg.d[i].partno);
                         $("select[id$='ddl_process']").val(msg.d[i].process);
                         $("select[id$='ddl_shift']").val(msg.d[i].shift);
                         $("input[id$='txt_fixedtime']").val(msg.d[i].fixedtime);
                         $("input[id$='txt_prdquty']").val(msg.d[i].prdqty);
                    }
                },
                error:function()
                {}
              });
}
function deleteactualdata(data)
{
    var con=window.confirm('Are You Sure Want To Delete This Registered Details');
    if(con==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/Deleteactualregister",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        alert("Record Deleted Successfully");
                        window.top.location.href="../Master/ActualTimeEntry.aspx";
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



//Fixture Values



function pageload()
{
    getfixname();
    getpart();
    getfixvalues();
}
function getfixname()
{
$.ajax({
                url:"../Master/Default.aspx/getfixname",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                var tbl = '<div><table style="border:solid 1px gray;" cellspacing="0" width="70%"><tr style="background-color:#105fe0;height:35px;"><td class="classTD" style="border-left:solid 1px #fff;width:50px;"><span class="classspan"><span>S.No</span></td><td class="classTD" style="width:150px;"><span class="classspan">Part Number</span></td><td class="classTD" style="width:150px;"><span class="classspan">Fixture Number</span></td><td class="classTD" style="width:100px;"><span class="classspan">Edit</span></td><td class="classTD" style="width:100px;"><span class="classspan">Delete</span></td></tr>';
                var count=0;
                    if(msg.d!=null && msg.d!="")
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            count+=1;
                            tbl+='<tr><td class="classTR" style="border-left:solid 1px #000;"><span class="classspan"><span>'+count+'</span></td><td class="classTR"><span class="classspan"><span>'+msg.d[i].partno+'</span></td><td class="classTR"><span class="classspan"><span>'+msg.d[i].fixname+'</span></td><td class="classTR"><div style="padding-left:20px;" ID=' + msg.d[i].fid + ' onclick="javascript:editname(this.id);"><img src="../Images/edit.png" style="width:28px; height:25px;cursor:pointer;" /></div></td><td class="classTR"><div style="padding-left:20px;" ID=' + msg.d[i].fid + ' onclick="javascript:deletename(this.id);"><img src="../Images/Delete.png" style="width:28px; height:25px;cursor:pointer;" /></div></td></tr>';
                        }
                        tbl+='</table></div>';
                        $("div[id$='div_fixname']").html(tbl);
                    }
                    else
                    {
                         tbl+='</table></div>';
                          $("div[id$='div_fixname']").html(tbl);
                    }
                    
                    
              },
                error:function()
                {}
              });
}
function deletename(d)
{
    var res=window.confirm('R U Sure Want to delte the Fixture Name');
    if(res==true)
    {
    $.ajax({
                url:"../Master/Default.aspx/deletefixname",
                data:"{'ID':'"+d+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!="" && msg.d!=null)
                    {
                        if(msg.d=="S")
                        {
                            getfixname();
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
}
function editname(d)
{
    $("input[id$='hdn_id']").val('');
    $("input[id$='hdn_id']").val(d);
    $.ajax({
                url:"../Master/Default.aspx/editfixname",
                data:"{'ID':'"+d+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!="" && msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                           // getpart();
                            $("select[id$='ddl_partno']").val(msg.d[i].partno);
                            $("input[id$='txt_fix']").val(msg.d[i].fixname);
                            $('#div_save').hide();
                            $('#div_updatge').show();
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

function getpart()
{
        $.ajax({
                url:"../Master/Default.aspx/Get_prtno",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    $("select[id$='ddl_partno']").get(0).options.length = 0;
                    $("select[id$='ddlpartno']").get(0).options.length = 0;
                    $("select[id$='ddl_partno']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    $("select[id$='ddlpartno']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_partno']").get(0).options[$("select[id$='ddl_partno']").get(0).options.length] = new Option(comma[count], comma[count]);
                            $("select[id$='ddlpartno']").get(0).options[$("select[id$='ddlpartno']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
              }
              
              
$(function()
{
    $('#btn_save').click(function()
    {
        var res=validatefixname();
        if(res==true)
        {
            save('0');
            
        }
        else
        {
        }
    });
});

$(function()
{
    $('#btn_update').click(function ()
    {
        var res=validatefixname();
        if(res==true)
        {
            var id=$("input[id$='hdn_id']").val();
            save(id);
             $('#div_save').show();
             $('#div_updatge').hide();
        }
        
    });
    
});
function save(id)
{

            var part=$("select[id$='ddl_partno']").val();
            var fixname=$("input[id$='txt_fix']").val();
            $.ajax({
                url:"../Master/Default.aspx/savefixname",
                data:"{'Partno':'"+part+"','Fixname':'"+fixname+"','ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    if(msg.d=="S")
                    {
                        getfixname();
                        getpart();
                        var fixname=$("input[id$='txt_fix']").val('');
                        $("input[id$='hdn_id']").val('');
                    }
                    else{
                    }
                    
                },
                error:function()
                {}
              });
}
function validatefixname()
{
    if(!v_partno())return false
    if(!v_fixname())return false
    return true;
}
function v_partno()
{
    var p= $("select[id$='ddl_partno']").val();
    if(p=="0" || p==null)
    {
        $("div[id$='div_error1']").show();
        $("span[id$='spnerror1']").text('Please Select Part No');
        return false;
    }
    else
    {
         $("div[id$='div_error1']").hide();
         return true;
    }
}

function v_fixname()
{
    var f= $("input[id$='txt_fix']").val();
    if(f=="" || f==null)
    {
        $("div[id$='div_error1']").show();
        $("span[id$='spnerror1']").text('Please Enter Fixture Name');
        return false;
    }
    else
    {
         $("div[id$='div_error1']").hide();
         return true;
    }
}



//===================Fixture Values===================================
function savevalues(id)
{
            var greenfrom='';
            var greento='';
            var yellowfrom='';
            var yellowto='';
            var redfrom='';
            var redto='';
            
            var part=$("select[id$='ddlpartno']").val();
            var fixname=$("select[id$='ddlfixname']").val();
            var operation=$("select[id$='ddloperation']").val();
            var life=$("input[id$='txtfixlife']").val();
            var gf=$("input[id$='txt_grom']").val();
            var gt=$("input[id$='txt_gto']").val();
            var yf=$("input[id$='txt_yfrom']").val();
            var yt=$("input[id$='txt_yto']").val();
            var rf=$("input[id$='txt_rfrom']").val();
            var rt=$("input[id$='txt_rto']").val();
            
            greenfrom=(parseInt(life)*parseInt(gf))/100;
            greento=(parseInt(life)*parseInt(gt))/100;
            $("input[id$='hdn_yellow']").val(parseInt(life)-parseInt(greento));
            var yellow=$("input[id$='hdn_yellow']").val();
            yellowfrom=(parseInt(life)*parseInt(yf))/100;
            yellowto=(parseInt(life)*parseInt(yt))/100;
            $("input[id$='hdn_red']").val(parseInt(life)-parseInt(yellowto));
            var red=$("input[id$='hdn_red']").val();
            redfrom=(parseInt(life)*parseInt(rf))/100;
            redto=(parseInt(life)*parseInt(rt))/100;
            
            $.ajax({
                url:"../Master/Default.aspx/savefixvalues",
                data:"{'Partno':'"+part+"','Fixname':'"+fixname+"','Operation':'"+operation+"','Life':'"+life+"','Gf':'"+gf+"','Gt':'"+gt+"','Yf':'"+yf+"','Yt':'"+yt+"','Rf':'"+rf+"','Rt':'"+rt+"','ID':'"+id+"','GrFrom':'"+greenfrom+"','Grto':'"+greento+"','YEfrom':'"+yellowfrom+"','Yeto':'"+yellowto+"','Refrom':'"+redfrom+"','Reto':'"+redto+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    if(msg.d=="S")
                    {
                        getfixvalues();
                        getpart();
                        $("select[id$='ddlfixname']").val('0');
                        $("select[id$='ddloperation']").val('0');
                        $("input[id$='txtfixlife']").val('');
                        $("input[id$='txt_grom']").val('');
                        $("input[id$='txt_gto']").val('');
                        $("input[id$='txt_yfrom']").val('');
                        $("input[id$='txt_yto']").val('');
                        $("input[id$='txt_rfrom']").val('');
                        $("input[id$='txt_rto']").val('');
                        $("input[id$='hdn_id']").val('');
                    }
                    else{
                    }
                    
                },
                error:function()
                {}
              });
}
$(function()
{
    $('#brn_fixvalues').click(function()
    {
        var res=validatafixvalues();
        if(res==true)
        {
            savevalues('0');
        }
    });
});
$(function()
{
    $('#btn_fupdate').click(function()
    {
        var res=validatafixvalues();
        if(res==true)
        {
            savevalues($("input[id$='hdn_id']").val());
             $('#div_fsave').show();
             $('#div_fupdate').hide();
             $("input[id$='hdn_id']").val('');
        }
    });
});
function validatafixvalues()
{
    if(!v_part())return false
    if(!v_fixn())return  false
    if(!v_operation())return false
    if(!v_life())return false
    if(!v_gf())return false
    if(!v_gt())return false
    if(!v_yf())return false
    if(!v_yt())return false
    if(!v_rf())return false
    if(!v_rt())return false
    return true;
}
function v_part()
{
    var p= $("select[id$='ddlpartno']").val();
    if(p=="0" || p==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Part No');
        $("select[id$='ddlpartno']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}

function v_fixn()
{
    var f= $("select[id$='ddlfixname']").val();
    if(f=="0" || f==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Fixture Name');
        $("select[id$='ddlfixname']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}

function v_operation()
{
    var op= $("select[id$='ddloperation']").val();
    if(op=="0" || op==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Select Operation');
        $("select[id$='ddloperation']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}
function v_life()
{
    var life = $("input[id$='txtfixlife']").val();
    if(life=="" || life==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Enter Fixture Life Time');
        $("select[id$='txtfixlife']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}
function v_gf()
{
    var gf = $("input[id$='txt_grom']").val();
    if(gf=="" || gf==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Enter Green From');
        $("select[id$='txt_grom']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}
function v_gt()
{
    var gt = $("input[id$='txt_gto']").val();
    if(gt=="" || gt==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Enter Green To');
        $("select[id$='txt_gto']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}
function v_yf()
{
    var yf = $("input[id$='txt_yfrom']").val();
    if(yf=="" || yf==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Enter Yellow From');
        $("select[id$='txt_yfrom']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}
function v_yt()
{
    var yt = $("input[id$='txt_yto']").val();
    if(yt=="" || yt==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Enter Yellow To');
        $("select[id$='txt_yto']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}
function v_rf()
{
    var rf = $("input[id$='txt_rfrom']").val();
    if(rf=="" || rf==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Enter Red From');
        $("select[id$='txt_rfrom']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}
function v_rt()
{
    var rt = $("input[id$='txt_rto']").val();
    if(rt=="" || rt==null)
    {
        $("div[id$='diverror']").show();
        $("span[id$='spn_error']").text('Please Enter Red To');
        $("select[id$='txt_rto']").focus();
        return false;
    }
    else
    {
         $("div[id$='diverror']").hide();
         return true;
    }
}
$(function()
{
    $("select[id$='ddlpartno']").change(function()
    {
       load_fixname($("select[id$='ddlpartno']").val(),'');
    });
});
function load_fixname(id,name)
{

    $.ajax({
                url:"../Master/Default.aspx/Get_fixname",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
              
                    $("select[id$='ddlfixname']").get(0).options.length = 0;
                    $("select[id$='ddlfixname']").get(0).options[0] = new Option("--- Select Fixture Name ---", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddlfixname']").get(0).options[$("select[id$='ddlfixname']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    if(name!="")
                    {
                        $("select[id$='ddlfixname']").val(name);
                    }
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
}
function getfixvalues()
{
$.ajax({
                url:"../Master/Default.aspx/getfixvalues",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                var tbl = '<div ><table style="border:solid 1px gray;" cellspacing="0" width="100%"><tr style="background-color:#105fe0;height:35px;"><td class="classTD" style="border-left:solid 1px #fff;width:50px;"><span class="classspan"><span>S.No</span></td><td class="classTD" style="width:100px;"><span class="classspan">Part Number</span></td><td class="classTD" style="width:100px;"><span class="classspan">Fixture Name</span></td><td class="classTD" style="width:100px;"><span class="classspan">Operation</span></td><td class="classTD" style="width:100px;"><span class="classspan">Life</span></td><td class="classTD" style="width:200px;background-color:green;"><span class="classspan">Gree Zone</span></td><td class="classTD" style="width:200px;background-color:orange;"><span class="classspan">Yellow Zone</span></td><td class="classTD" style="width:200px;background-color:red;"><span class="classspan">Red Zone</span></td><td class="classTD" style="width:100px;"><span class="classspan">Edit</span></td><td class="classTD" style="width:100px;"><span class="classspan">Delete</span></td></tr>';
                var count=0;
                var operat='';
                    if(msg.d!=null && msg.d!="")
                    {
                  
                        for(var i=0;i<msg.d.length;i++)
                        {
                            count+=1;
                            if(msg.d[i].operation=="1")
                            {
                                operat="FIRST";
                            }
                            if(msg.d[i].operation=="2")
                            {
                                operat="SECOND";
                            }
                            tbl+='<tr><td class="classTR" style="border-left:solid 1px #000;"><span class="classspan"><span>'+count+'</span></td><td class="classTR"><span class="classspan"><span>'+msg.d[i].partno+'</span></td><td class="classTR"><span class="classspan"><span>'+msg.d[i].fixname+'</span></td><td class="classTR"><span class="classspan"><span>'+operat+'</span></td><td class="classTR"><span class="classspan"><span>'+commaSeparateNumber(msg.d[i].life)+'</span></td><td class="classTR" ><span class="classspan"><span>'+commaSeparateNumber(msg.d[i].gf)+' TO '+commaSeparateNumber(msg.d[i].gt)+' %</span></td><td class="classTR"><span class="classspan"><span>'+commaSeparateNumber(msg.d[i].yf)+' TO '+commaSeparateNumber(msg.d[i].yt)+' %</span></td><td class="classTR"><span class="classspan"><span>'+commaSeparateNumber(msg.d[i].rf)+' TO '+commaSeparateNumber(msg.d[i].rt)+' %</span></td><td class="classTR"><div style="padding-left:20px;" ID=' + msg.d[i].id + ' onclick="javascript:editvalue(this.id);"><img src="../Images/edit.png" style="width:28px; height:25px;cursor:pointer;" /></div></td><td class="classTR"><div style="padding-left:20px;" ID=' + msg.d[i].id + ' onclick="javascript:deletevalue(this.id);"><img src="../Images/Delete.png" style="width:28px; height:25px;cursor:pointer;" /></div></td></tr>';
                         
                        }
                          tbl+='</table></div>';
                          $("div[id$='div_fixvalues']").html(tbl);
                    }
                    else
                    {
                         tbl+='</table></div>';
                          $("div[id$='div_fixvalues']").html(tbl);
                    }
                    
                    
              },
                error:function()
                {}
              });
}

function editvalue(d)
{
    $("input[id$='hdn_id']").val('');
    $("input[id$='hdn_id']").val(d);
    $.ajax({
                url:"../Master/Default.aspx/editfixvalues",
                data:"{'ID':'"+d+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!="" && msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            $("select[id$='ddlpartno']").val(msg.d[i].partno);
                            load_fixname(msg.d[i].partno,msg.d[i].fixname);
                            $("select[id$='ddloperation']").val(msg.d[i].operation);
                            $("input[id$='txtfixlife']").val(msg.d[i].life);
                            $("input[id$='txt_grom']").val(msg.d[i].gf);
                            $("input[id$='txt_gto']").val(msg.d[i].gt);
                            $("input[id$='txt_yfrom']").val(msg.d[i].yf);
                            $("input[id$='txt_yto']").val(msg.d[i].yt);
                            $("input[id$='txt_rfrom']").val(msg.d[i].rf);
                            $("input[id$='txt_rto']").val(msg.d[i].rt);
                            
                            $('#div_fsave').hide();
                            $('#div_fupdate').show();
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

function commaSeparateNumber(val){
    while (/(\d+)(\d{3})/.test(val.toString())){
      val = val.toString().replace(/(\d+)(\d{3})/, '$1'+','+'$2');
    }
    return val;
  }
  function  deletevalue(d)
  {
     var res=window.confirm('R U Sure Want to delte the Fixture Values');
    if(res==true)
    {
    $.ajax({
                url:"../Master/Default.aspx/deletefixvalue",
                data:"{'ID':'"+d+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!="" && msg.d!=null)
                    {
                        if(msg.d=="S")
                        {
                           getfixvalues();
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
  }