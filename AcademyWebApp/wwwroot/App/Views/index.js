class Index {

    get Students() {
        return this._students;
    }
    set Students(value) {
        this._students = value;
    }

    get IsLogon() {
        return Globals.IsLogon;
    }

    constructor($http) {
        this._students = [];
        this.Http = $http;
    }

    RequestStudents() {
        this.Http.get("/api/Students").then(
            (response) => {
                this.Students.length = 0;
                for (let i in response.data) {
                    this.Students.push(response.data[i]);
                }
            },
            function errorCallback(response) {
                console.log("POST-ing of data failed");
            }
        );
    }
}
Index.$inject = ['$http'];

app.
    component('index', {
        templateUrl: './App/Views/index.html',
        controller: ('Index', Index),
        controllerAs: 'vm'
    });