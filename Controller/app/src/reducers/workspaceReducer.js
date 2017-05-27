export default function workspaceReducer(workspace = {}, action) {
    if (action.type == 'VOCABULARY_FOLDER_CREATED') {
        return vocabularyFolderCreated(workspace, action);
    }
    if (action.type == 'VOCABULARY_FOLDERS_RETRIEVED') {
        return vocabularyFoldersRetrieved(workspace, action);
    }
    switch (action.type) {
        case 'CREATE_VOCABULARY_FOLDER':
            if (workspace.vocabularyFolders) {
                const vocabularyFolders = [...workspace.vocabularyFolders, action.folderName];
                return Object.assign({}, workspace, { vocabularyFolders });
            }
            return Object.assign({}, workspace, { vocabularyFolders: [action.folderName] });
        
        default:
            return workspace;
    }
}

function vocabularyFolderCreated(workspace, action) {
    const folder = Object.assign({}, action.folder);
    if (workspace.vocabularyFolders) {
        const vocabularyFolders = [...workspace.vocabularyFolders, folder];
        return Object.assign({}, workspace, { vocabularyFolders });
    }
    return Object.assign({}, workspace, { vocabularyFolders: [folder] });
}

function vocabularyFoldersRetrieved(workspace, action) {
    const folders = [...action.folders];
    return Object.assign({}, workspace, { vocabularyFolders: folders });
}