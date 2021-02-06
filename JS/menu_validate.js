
$(function()
{
    $('#link_productiondata').click(function()
    {
        var txtdowntype=$("input[id$='txtdowntype']").val();
        var txtdownstart=$("input[id$='txtdownstart']").val();
        var txtdownend=$("input[id$='txtdownend']").val();
        var txtdowntotal=$("input[id$='txtdowntotal']").val();
       

    if((txtdowntype!="")&&(txtdownstart!="")&&(txtdownend==""))
    {
        alert('Please Enter End Time ');
        $("input[id$='txtdownend']").focus();
        return false;
    }
    else
   if((txtdowntype!="")&&(txtdownstart!="")&&(txtdownend!="")&&(txtdowntotal!=""))
    {
        alert('Please click the Add button');
      
        return false;
    }
 
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


$(function()
{
    $('#link_production_doc').click(function()
    {
        var txtdowntype=$("input[id$='txtdowntype']").val();
        var txtdownstart=$("input[id$='txtdownstart']").val();
        var txtdownend=$("input[id$='txtdownend']").val();
        var txtdowntotal=$("input[id$='txtdowntotal']").val();
       

    if((txtdowntype!="")&&(txtdownstart!="")&&(txtdownend==""))
    {
        alert('Please Enter End Time ');
        $("input[id$='txtdownend']").focus();
        return false;
    }
    else
   if((txtdowntype!="")&&(txtdownstart!="")&&(txtdownend!="")&&(txtdowntotal!=""))
    {
        alert('Please click the Add button');
      
        return false;
    }
 
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

$(function()
{
    $('#link_dwntime').click(function()
    {
        var txtdowntype=$("input[id$='txtdowntype']").val();
        var txtdownstart=$("input[id$='txtdownstart']").val();
        var txtdownend=$("input[id$='txtdownend']").val();
        var txtdowntotal=$("input[id$='txtdowntotal']").val();
       

    if((txtdowntype!="")&&(txtdownstart!="")&&(txtdownend==""))
    {
        alert('Please Enter End Time ');
        $("input[id$='txtdownend']").focus();
        return false;
    }
    else
   if((txtdowntype!="")&&(txtdownstart!="")&&(txtdownend!="")&&(txtdowntotal!=""))
    {
        alert('Please click the Add button');
      
        return false;
    }
 
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
