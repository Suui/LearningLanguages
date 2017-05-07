import React from 'react';

class LoginPage extends React.Component {
    render() {
        return (
            <div>
                <h1>Login</h1>
                <form action="/login" method="post">
                    <input name="username" type="text"/>
                    <input name="password" type="password"/>
                    <input type="submit" value="login"/>
                </form>
            </div>
        );
    }
}

export default LoginPage;