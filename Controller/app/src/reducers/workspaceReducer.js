import * as types from '../actions/types/workspace';

export default function workspaceReducer(workspace = { vocabularyFolders: [] }, action) {

    function vocabularyFolderCreated() {
        const folder = Object.assign({}, action.folder);
        if (workspace.vocabularyFolders) {
            const vocabularyFolders = [...workspace.vocabularyFolders, folder];
            return Object.assign({}, workspace, { vocabularyFolders });
        }
        return Object.assign({}, workspace, { vocabularyFolders: [folder] });
    }

    function vocabularyFoldersRetrieved() {
        const folders = [...action.folders];
        return Object.assign({}, workspace, { vocabularyFolders: folders });
    }

    const execute = {
        [types.VOCABULARY_FOLDER_CREATED]: () => vocabularyFolderCreated(),
        [types.VOCABULARY_FOLDERS_RETRIEVED]: () => vocabularyFoldersRetrieved(),
    };
    
    return execute[action.type] ? execute[action.type]() : workspace;
}