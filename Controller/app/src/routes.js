import React from 'react';
import { Route, IndexRoute } from 'react-router';
import App from './components/App';
import AppLayout from './components/AppLayout';
import HomePage from './components/home/HomePage';
import LoginPage from './components/login/LoginPage';

export default (
	<Route component={App}>
		<Route path="/login" component={LoginPage}/>
		<Route path="/" component={AppLayout}>
			<IndexRoute component={HomePage}/>
		</Route>
	</Route>
);
