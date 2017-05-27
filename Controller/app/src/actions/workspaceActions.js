import * as workspaceApi from '../api/workspaceApi';

export function displayVocabularyFolderCreation(displayed) {
    return { type: 'DISPLAY_VOCABULARY_FOLDER_CREATION', displayed };
}

export function createVocabularyFolder(folderName) {
    return { type: 'CREATE_VOCABULARY_FOLDER', folderName };
}

export function vocabularyFolderCreated(folder) {
    return { type: 'VOCABULARY_FOLDER_CREATED', folder };
}

export function vocabularyFoldersRetrieved(folders) {
    return { type: 'VOCABULARY_FOLDERS_RETRIEVED', folders };
}

export function createVocabularyFolderAsync(folderName) {
    return dispatch => {
        return workspaceApi.createVocabularyFolder(folderName)
        .then(savedFolder => {
            dispatch(vocabularyFolderCreated(savedFolder));
        })
        .catch(error => {
            throw(error);
        });
    };
}

export function retrieveVocabularyFolders() {
    return dispatch => {
        return workspaceApi.retrieveVocabularyFolders()
        .then(folders => {
            dispatch(vocabularyFoldersRetrieved(folders));
        })
        .catch(error => {
            throw(error);
        });
    };
}