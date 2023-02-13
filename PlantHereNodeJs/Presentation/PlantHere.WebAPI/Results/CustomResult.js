class CustomResult
{
    constructor(Data,Errors) {
        this.data = Data;
        this.errors =  Errors;
    }
    
    static Success(Data)
    {
        return new CustomResult(Data,null)
    }

    static Fail(Errors)
    {
        return new CustomResult(null,Errors)
    }

    static Fail(Errors)
    {
        return new CustomResult(null,Errors)
    }

    static Success(Data)
    {
        return new CustomResult(Data,null)
    }
    
}

module.exports = {CustomResult}


