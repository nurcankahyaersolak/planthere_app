const setRole = (text) => {
    return (req, res, next) => {
      req.allowedRoles = text;
      next();
    };
};

module.exports = setRole