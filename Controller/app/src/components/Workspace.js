import React, { PropTypes } from 'react';
import { Link } from 'react-router';
import { TiFolderAdd } from 'react-icons/lib/ti';

const Workspace = ({
    vocabularyFolders,
    displayVocabularyFolderCreation,
    vocabularyFolderCreationDisplayed,
    vocabularyFolderNameChanged,
    createVocabularyFolder
}) => {
    
    return (
        <div className="workspace">
            <div className="root">
                Workspace
            </div>
            <div className="vocabulary">
                Vocabulary
                <Link id="add-vocabulary-folder" className="add-vocabulary-folder" to="/" onClick={displayVocabularyFolderCreation}>
                    <TiFolderAdd/>
                </Link>
            </div>
            {vocabularyFolderCreationDisplayed &&
                <div>
					<input type="text" name="vocabularyFolderName" onChange={vocabularyFolderNameChanged}/>
					<input type="submit" name="createVocabularyFolder" value="Create" onClick={createVocabularyFolder}/>
				</div>}
            {vocabularyFolders.map((folder, index) => {
				return <div className="vocabulary-folder" key={index}>{folder.name}</div>;
			})}
        </div>
    );
};

Workspace.propTypes = {
    vocabularyFolders: PropTypes.array.isRequired,
    displayVocabularyFolderCreation: PropTypes.func.isRequired,
    vocabularyFolderCreationDisplayed: PropTypes.bool.isRequired,
    vocabularyFolderNameChanged: PropTypes.func.isRequired,
    createVocabularyFolder: PropTypes.func.isRequired
};

export default Workspace;