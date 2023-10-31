function TWAException(errorCode, description, stack) {
    this.name = 'TWAException';
    this.description = description;
    this.errorCode = errorCode;
    this.stack = stack;
  }
  
  TWAException.prototype = Object.create(Error.prototype);
  TWAException.prototype.constructor = TWAException;
  
  export default TWAException;
  