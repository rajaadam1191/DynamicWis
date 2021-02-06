function editfname(id)
{
   
    $("input[id$='hdn_fid']").val(id);
    $("div[id$='div_fistrueupdate']").show();  
    $("div[id$='div_fistruesave']").hide();      
    $.ajax({

//                url:"../Master/Default.aspx/editfixname",
                url:"../Fixture/FixtureName.aspx/editfixname",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            $("select[id$='ddl_funit']").val(msg.d[i].unit);   
                            $("select[id$='ddl_ftooltype']").val(msg.d[i].type);   
                            $("select[id$='ddl_fline']").val(msg.d[i].line);   
                            $("select[id$='ddl_model']").val(msg.d[i].model);   
                            $("input[id$='txt_fixtureno']").val(msg.d[i].fixtureno);   
                            $("select[id$='ddl_partnumber']").val(msg.d[i].partno);
                            $("select[id$='ddl_fixcell']").val(msg.d[i].cell);   
                        }
                    }
                },
                error:function()
                {}
              }); 
}

function deletefname(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Fixture Name');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deletefixname",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../Fixture/FixtureName.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function deletefixvalue(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Fixture Values');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deletefixvalue1",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../Fixture/FixtureValues.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function loadfixnum(id)
{
     $.ajax({
        url:"../Fixture/FixtureValues.aspx/BindToolNumberEdit",
        data:"{'fixid':'"+id+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data)
        {
//        ////
//            var txt_toolnumber = $("[id*=txt_toolnumber]");
//            txt_toolnumber.empty();
//            $.each(r.d, function () {
//                txt_toolnumber.append($("<option></option>").val(this['Value']).html(this['Text']));
//            });
            var ddl_fixturename = $("[id*=ddl_fixturename]");
            ddl_fixturename.empty().append('<option  value="0">--- Select Fixture Number ---</option>');
            $.each(data.d, function(key, value) {
            ddl_fixturename.append($("<option selected='selected'></option>").val(value.ID).html(value.FixNumber));
            });
            
           GetProcess();
        },
        error:function()
        {}
      });
}
function editfixvalue(id)
{
    $("input[id$='hdn_id']").val(id);
    $("div[id$='div_fistrueupdate']").show();  
    $("div[id$='div_fistruesave']").hide();    
    $("div[id$='div_fix_life_extended']").show();  
    $.ajax({
            url:"../Master/Default.aspx/editfixvalues",
            data:"{'ID':'"+id+"'}",
            type:"POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg)
            {
                if(msg.d!=null)
                {
                    for(var i=0;i<msg.d.length;i++)
                    {
                        $("input[id$='hdn_operation']").val(msg.d[i].operation);
                        loadfixnum(msg.d[i].fixno);
                        $("select[id$='ddl_partnumber']").val(msg.d[i].partno);   
                        $("select[id$='ddl_fixturename']").val(msg.d[i].fixno);   
                        $("select[id$='ddloperation']").val(msg.d[i].operation); 
                        $("select[id$='ddl_availability']").val(msg.d[i].drawing);  
                        $("input[id$='txt_grom']").val(msg.d[i].gf);   
                        $("input[id$='txt_gto']").val(msg.d[i].gt);   
                        $("input[id$='txt_yfrom']").val(msg.d[i].yf);   
                        $("input[id$='txt_yto']").val(msg.d[i].yt); 
                        $("input[id$='txt_rfrom']").val(msg.d[i].rf);   
                        $("input[id$='txt_rto']").val(msg.d[i].rt); 
                        $("input[id$='txtfixlife']").val(msg.d[i].life); 
                    }
                }
            },
            error:function()
            {}
          }); 
}


function valMbufixture()
{
    if(!valunit())return false
    if(!valtype())return false
    if(!valline())return false
    if(!valmodelno())return false
    if(!valfixtureno())return false
    //if(!valpartno())return false
    if(!valcell())return false
}

function valcell()
{
    var cell=$("select[id$='ddl_fixcell']").val();
    if(cell !="0" && cell !="--- Select Fixture Cell ---")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_fixcell']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Cell');
        return false;
    }
}

function valunit()
{
    var unt=$("select[id$='ddl_funit']").val();
    if(unt!="0")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_funit']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Unit');
        return false;
    }
}

function valtype()
{
    var type=$("select[id$='ddl_ftooltype']").val();
    if(type!="0")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_ftooltype']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Fixture Type');
        return false;
    }
}
function valline()
{
    var line=$("select[id$='ddl_fline']").val();
    if(line!="0")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_fline']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Line/ Machine');
        return false;
    }
}
function valmodelno()
{
    var modelno=$("select[id$='ddl_model']").val();
    if(modelno!="0")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_model']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Model');
        return false;
    }
}
function valfixtureno()
{
    var fno=$("input[id$='txt_fixtureno']").val();
    if(fno!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_fixtureno']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Fixture Number');
        return false;
    }
}
function valpartno()
{
    var pno=$("select[id$='ddl_partnumber']").val();
    if(pno!="0" && pno!="--- Select Part Number ---")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_partnumber']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Part Number');
        return false;
    }
}


function GetProcess()
{
var comma=null;
var part=[];
$.ajax({
        url:"../Master/Default.aspx/Get_prtprocess",
        data:"{}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            $("select[id$='ddloperation']").get(0).options.length = 0;
            $("select[id$='ddloperation']").get(0).options[0] = new Option("-Select-", "0");
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
                        $("select[id$='ddloperation']").get(0).options[$("select[id$='ddloperation']").get(0).options.length] = new Option(comma[count], "1");                            
                    }
                    else if(comma[count]=="OP2")
                    {
                        $("select[id$='ddloperation']").get(0).options[$("select[id$='ddloperation']").get(0).options.length] = new Option(comma[count], "2");
                    }
                    else
                    {
                        $("select[id$='ddloperation']").get(0).options[$("select[id$='ddloperation']").get(0).options.length] = new Option(comma[count], comma[count]);
                    }
                }
            }
            
            var p=$("input[id$='hdn_operation']").val();
            if(p!="")
            {
                $("select[id$='ddloperation']").val(p);
            }
            
            part=null;
            comma=null;
          },
            error:function()
            {}
    });
              
}

function valMbufixValues()
{
    //if(!valpartno())return false
    if(!valFixtureNo())return false
    if(!valOperation())return false
    if(!valfixturelife())return false
    if(!valDrawingAvail())return false
    if(!valgf())return false
    if(!valgt())return false
    if(!valyf())return false
    if(!valyt())return false
    if(!valrf())return false
    if(!valrt())return false
}
function valMbufixValues1()
{
    //if(!valpartno())return false
    if(!valFixtureNo())return false
    if(!valOperation())return false
    if(!valfixturelife())return false
    if(!valDrawingAvail())return false
    if(!valgf())return false
    if(!valgt())return false
    if(!valyf())return false
    if(!valyt())return false
    if(!valrf())return false
    if(!valrt())return false
    
    var fixture=$("select[id$='ddl_fixclose']").val();
    if(fixture =="No")
    {
     if(!val_extend())return false
    }
    else
    {
    }
}

function val_extend()
{
    var extend=$("input[id$='txt_extended']").val();
    if(extend!="" && extend!="0")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_extended']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Life Extended');
        return false;
    }
}

function valFixtureNo()
{
    var pname=$("select[id$='ddl_fixturename']").val();
    if(pname!="0" && pname!="--- Select Fixture Number ---")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_fixturename']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Fixture Number');
        return false;
    }
}

function valOperation()
{
    var oper=$("select[id$='ddloperation']").val();
    if(oper!="0" && oper!="--- Select Operation ---")
    {
        $("input[id$='hdn_operation']").val(oper);
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddloperation']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Operation');
        return false;
    }
}
function valfixturelife()
{
    var flife=$("input[id$='txtfixlife']").val();
    if(flife!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txtfixlife']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Fixture Life');
        return false;
    }
}

function valDrawingAvail()
{
    var oper=$("select[id$='ddl_availability']").val();
    if(oper!="0" && oper!="--- Select Drawing Availability ---")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_availability']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Drawing Availability');
        return false;
    }
}

function valgf()
{
    var gf=$("input[id$='txt_grom']").val();
    if(gf!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_grom']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the green from range');
        return false;
    }
}
function valgt()
{
    var gt=$("input[id$='txt_gto']").val();
    if(gt!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_gto']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the green to range');
        return false;
    }
}
function valyf()
{
    var yf=$("input[id$='txt_yfrom']").val();
    if(yf!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_yfrom']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Yellow from range');
        return false;
    }
}
function valyt()
{
    var yt=$("input[id$='txt_yto']").val();
    if(yt!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_yto']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Yellow to range');
        return false;
    }
}
function valrf()
{
    var rf=$("input[id$='txt_rfrom']").val();
    if(rf!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_rfrom']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Red from range');
        return false;
    }
}
function valrt()
{
    var rt=$("input[id$='txt_rto']").val();
    if(rt!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_rto']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Red to range');
        return false;
    }
}

$(function()
{
    $("select[id$='ddl_partnumber']").change(function()
    {
    var value=$("select[id$='ddl_partnumber']").val();
     $('select[id$=ddl_partnumber]').find('option[value="' + value + '"]').attr("selected", "selected");
    });
    
});