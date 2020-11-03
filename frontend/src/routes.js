import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";

import Login from './pages/Login';
import Home from './pages/Home';
// import Dashboard from './pages/Dashboard';
// import Wallet from './pages/Wallet';

const Routes = () => (
    <BrowserRouter> 
        <Switch>
            <Route exact path ="/" component={Login}/>
            <Route exact path ="/home" component={Home}/>
        </Switch>
    </BrowserRouter>
);

export default Routes;