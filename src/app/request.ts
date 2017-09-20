export class Request{
    constructor(public employeeCode:string,
        public supervisorCode:string,public typeOfRequest:string,public newpacode:string,
        public newpsacode:string,public newOucode:string,
        public newCcCode:string,public requestStatus:string,
        public pendingWith:string,public requestId?:string,public dateofrequest?:string ){}
}