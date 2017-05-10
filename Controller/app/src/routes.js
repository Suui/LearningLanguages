import React from 'react';
import { Route, IndexRoute } from 'react-router';
import App from './components/App';
import LoginPage from './components/LoginPage';
import AppLayout from './components/AppLayout';
import DashboardPage from './components/DashboardPage';

export default (
	<Route component={App}>
		<Route path="/login" component={LoginPage}/>
		<Route path="/" component={AppLayout}>
			<IndexRoute component={DashboardPage}/>
		</Route>
	</Route>
);
