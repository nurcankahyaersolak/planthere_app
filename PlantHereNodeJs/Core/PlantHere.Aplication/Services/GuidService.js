
function _p8(s) {  
    var p = (Math.random().toString(16)+"000000000").substr(2,8);  
    return s ? "-" + p.substr(0,4) + "-" + p.substr(4,4) : p ;  
}  

function _date()
{    
    var currentDate = new Date();
    return `_${currentDate.getFullYear()}${currentDate.getMonth()+1}${currentDate.getDate()}${currentDate.getHours()}${currentDate.getMinutes()}${currentDate.getSeconds()}${currentDate.getMilliseconds()}`;
}


function dateNow()
{    
    var currentDate = new Date();
    return `${currentDate.getFullYear()}-${currentDate.getMonth()+1}-${currentDate.getDate()} ${currentDate.getHours()}:${currentDate.getMinutes()}:${currentDate.getSeconds()}.${currentDate.getMilliseconds()}`;
}

function createGuid() {  
    return _p8() + _p8(true) + _p8(true) + _p8() + _date();  
}  
   

module.exports = {createGuid,dateNow}