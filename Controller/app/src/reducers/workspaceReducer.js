export default function workspaceReducer(workspace = {}, action) {
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