class StoreCustomer {

    //constructor(theName: string) {
    //    this.name = theName;
    //}

    constructor(private firstName: string, private lastName: string) {
       
    }

    public visit: number = 0;
    private ourName: string;

    //public showName(name:string):boolean {
    //    alert(name);
    //    return true;
    //}

    //public showName(name: string) {
    //    alert(this.ourName);       
    //}

    public showName() {
        alert(this.firstName + " " + this.lastName);
    }

    set name(val) {
        this.ourName = val;
    }

    get name() {
        return this.ourName;
    }
}

//let cust = new StoreCustomer();
//cust.visit = 10;
