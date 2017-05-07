import React, { PropTypes } from 'react';
import Header from './common/Header';

class AppLayout extends React.Component {
	render() {
		return (
			<div>
                <Header/>
                <div className="app-content">
                    {this.props.children}
                </div>
			</div>
		);
	}
}

AppLayout.propTypes = {
	children: PropTypes.object.isRequired
};

export default AppLayout;
