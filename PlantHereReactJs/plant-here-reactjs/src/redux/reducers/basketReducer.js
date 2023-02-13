import { FETCH_BASKET } from '../../redux/constants/basketConstant';

const initialState = {
    basket: null,
    basketItems: [],
    basketItemsCount: 0
}

const basketReducer = (state = initialState, action) => {
    switch (action.type) {
        case FETCH_BASKET:
            if (action.payload) {
                return {
                    ...state,
                    basket: action.payload,
                    basketItemsCount: action.payload?.basketItems?.reduce((acc, o) => acc + o.count, 0),
                    basketItems: action.payload?.basketItems
                }
            }
            else {
                return initialState
            }
        default:
            return state;
    }
}

export default basketReducer;