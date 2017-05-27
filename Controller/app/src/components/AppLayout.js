import React, { PropTypes } from 'react';
import { connect } from 'react-redux';
import { Grid, Row, Col } from 'react-flexbox-grid';
import { TiFolderAdd } from 'react-icons/lib/ti';
import { Link } from 'react-router';
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

	folderCreationForm() {
		if (this.state.displayFolderCreation) {
			return (
				<div>
					<input type="text" name="vocabularyFolderName" onChange={this.setupVocabularyFolderName}/>
					<input type="submit" name="createVocabularyFolder" value="Create" onClick={this.createVocabularyFolder}/>
				</div>
			);
		}
		return null;
	}

	vocabularyFolders() {
		if (this.props.workspace && this.props.workspace.vocabularyFolders) {
			return this.props.workspace.vocabularyFolders.map((folder, index) => {
				return <div className="vocabulary-folder" key={folder.id}>{folder.name}</div>;
			});
		}
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
					{this.folderCreationForm()}
					{this.vocabularyFolders()}
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
	workspace: PropTypes.object.isRequired,
	createVocabularyFolder: PropTypes.func.isRequired,
	// createVocabularyFolderAsync: PropTypes.func.isRequired
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
