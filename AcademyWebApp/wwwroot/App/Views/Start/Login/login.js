class Login {

    get Email() {
        return this._email;
    }

    set Email(value) {
        this._email = value;
    }

    get Password() {
        return this._password;
    }

    set Password(value) {
        this._password = value;
    }

    constructor($http) {
        this.Http = $http;
    }

    Login() {
        //alert("user:" + this.Email + " password:" + this.Password);

        var data =
        {
            email: this.Email,
            password: this.Password
        };

        this.Http.post("/Api/login",
            data

        ).then(
            (response) => {
                if (response.data === true)
                    Globals.IsLogon = true;
            },
            function errorCallback(response) {
                console.log("POST-ing of data failed");
            }
        );

       
    }
}

Login.$inject = ['$http'];

app.
    component('login', {
        templateUrl: './App/Views/Start/Login/login.html',
        controller: ('Login', Login),
        controllerAs: 'vm'
    });