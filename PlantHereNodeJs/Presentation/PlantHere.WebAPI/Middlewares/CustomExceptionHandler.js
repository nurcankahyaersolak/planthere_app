const { CustomResult } = require('../Results/CustomResult');

const CustomExceptionHandle = (err, req, res, next) => {

    let status = err.status || 500
    const error = { message: err.message }

    if (err.name.includes('Token')) {
        status = 401
    }
    else if (err.name == 'SequelizeDatabaseError' || err.name.includes('Validation')) {
        status = 400
    }

    res.status(status).json(CustomResult.Fail([error]))
}

const CatchErrors = action => (req, res, next) => {
    action(req, res).catch(next)
}

const AsyncHandler = fn => (req, res, next) => {
    return Promise
        .resolve(fn(req, res, next))
        .catch(next);
};

module.exports = { CustomExceptionHandle, CatchErrors,AsyncHandler }