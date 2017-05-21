import { combineReducers } from 'redux';
import workspace from './workspaceReducer';

const rootReducer = combineReducers({
    workspace
});

export default rootReducer;