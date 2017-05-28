import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { Grid, Row, Col } from 'react-flexbox-grid';
import { TiFolderAdd } from 'react-icons/lib/ti';
import { Link } from 'react-router';
import Workspace from './Workspace';
import * as workspaceActions from '../actions/workspaceActions';

class AppLayout extends React.Component {

	constructor(props, context) {
		super(props, context);

		this.state = {
			newVocabularyFolderName: '',
			displayFolderCreation: false
		};

		this.displayFolderCreation = this.displayFolderCreation.bind(this);
		this.setupVocabularyFolderName = this.setupVocabularyFolderName.bind(this);
		this.createVocabularyFolder = this.createVocabularyFolder.bind(this);
	}

	displayFolderCreation() {
		const nextState = Object.assign({}, this.state, { displayFolderCreation: true });
		this.setState(nextState);
	}

	hideFolderCreation() {
		const nextState = Object.assign({}, this.state, { displayFolderCreation: false });
		this.setState(nextState);
	}

	setupVocabularyFolderName(event) {
		const currentFolderName = event.target.value;
		const nextState = Object.assign({}, this.state, { newVocabularyFolderName: currentFolderName });
		this.setState(nextState);
	}

	createVocabularyFolder() {
		this.props.createVocabularyFolder(this.state.newVocabularyFolderName);
		this.hideFolderCreation();
	}

	render() {
		return (
			<div>
				<nav>
					Workspace
				</nav>
				<Workspace
					vocabularyFolders={this.props.workspace.vocabularyFolders}
					displayVocabularyFolderCreation={this.displayFolderCreation}
					vocabularyFolderCreationDisplayed={this.state.displayFolderCreation}
					vocabularyFolderNameChanged={this.setupVocabularyFolderName}
					createVocabularyFolder={this.createVocabularyFolder}
				/>
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
	workspace: PropTypes.object.isRequired,
	createVocabularyFolder: PropTypes.func.isRequired
};

function mapStateToProps(state, ownProps) {
	return {
		workspace: state.workspace
	};
}

function mapDispatchToProps(dispatch) {
	return {
		createVocabularyFolder: folderName => dispatch(workspaceActions.createVocabularyFolder(folderName))
	};
}

export default connect(mapStateToProps, mapDispatchToProps)(AppLayout);
