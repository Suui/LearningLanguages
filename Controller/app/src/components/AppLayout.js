import React, { PropTypes } from 'react';
import { Grid, Row, Col } from 'react-flexbox-grid';
import { TiFolderAdd } from 'react-icons/lib/ti';
import { Link } from 'react-router';

class AppLayout extends React.Component {

	constructor() {
		super();
		this.displayFolderCreation = this.displayFolderCreation.bind(this);
		this.state = {
			displayFolderCreation: false
		};
	}

	displayFolderCreation() {
		const nextState = {
			displayFolderCreation: true
		};
		this.setState(nextState);
	}

	render() {
		return (
			<div>
				<nav>
					Workspace
				</nav>
				<div className="workspace">
					<div className="root">
						Workspace
					</div>
					<div className="vocabulary">
						Vocabulary
						<Link to="/" onClick={this.displayFolderCreation} id="add-vocabulary-folder" className="add-vocabulary-folder">
							<TiFolderAdd/>
						</Link>
					</div>
					<div className="set-vocabulary-folder-name">
						<input type="text" name="vocabularyFolderName"/>
						<button>Create</button>
					</div>
				</div>
				<Grid>
					<Row>
						<Col/>
					</Row>
				</Grid>
			</div>
		);
	}
}

AppLayout.propTypes = {
	children: PropTypes.object.isRequired
};

export default AppLayout;
