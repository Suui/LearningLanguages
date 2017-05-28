import * as types from './types/workspace';
import * as workspaceApi from '../api/workspaceApi';

export function displayVocabularyFolderCreation(displayed) {
    return { type: types.DISPLAY_VOCABULARY_FOLDER_CREATION, displayed };
}

export function vocabularyFolderCreated(folder) {
    return { type: types.VOCABULARY_FOLDER_CREATED, folder };
}

export function vocabularyFoldersRetrieved(folders) {
    return { type: types.VOCABULARY_FOLDERS_RETRIEVED, folders };
}

export function createVocabularyFolder(folderName) {
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