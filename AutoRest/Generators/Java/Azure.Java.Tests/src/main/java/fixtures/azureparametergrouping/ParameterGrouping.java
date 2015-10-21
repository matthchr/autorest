/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 * 
 * Code generated by Microsoft (R) AutoRest Code Generator 0.11.0.0
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

package fixtures.azureparametergrouping;

import com.microsoft.rest.ServiceCallback;
import com.microsoft.rest.ServiceException;
import retrofit.Call;
import com.squareup.okhttp.ResponseBody;
import retrofit.http.POST;
import retrofit.http.Header;

/**
 * An instance of this class provides access to all the operations defined
 * in ParameterGrouping.
 */
public interface ParameterGrouping {
    /**
     * The interface defining all the services for ParameterGrouping to be
     * used by Retrofit to perform actually REST calls.
     */
    interface ParameterGroupingService {
        @POST("/parameterGrouping/postRequired/{path}")
        Call<ResponseBody> postRequired(@Header("accept-language") String acceptLanguage, String parameterGroupingPostRequiredParameters);

        @POST("/parameterGrouping/postOptional")
        Call<ResponseBody> postOptional(@Header("accept-language") String acceptLanguage, String parameterGroupingPostOptionalParameters);

        @POST("/parameterGrouping/postMultipleParameterGroups")
        Call<ResponseBody> postMultipleParameterGroups(@Header("accept-language") String acceptLanguage, String firstParameterGroup, String secondParameterGroup);

    }
    /**
     * Post a bunch of required parameters grouped
     *
     * @param parameterGroupingPostRequiredParameters Additional parameters for the operation
     * @throws ServiceException the exception wrapped in ServiceException if failed.
     */
    void postRequired(ParameterGroupingPostRequiredParameters parameterGroupingPostRequiredParameters) throws ServiceException;

    /**
     * Post a bunch of required parameters grouped
     *
     * @param parameterGroupingPostRequiredParameters Additional parameters for the operation
     * @param serviceCallback the async ServiceCallback to handle successful and failed responses.
     * @return the {@link Call} object
     */
    Call<ResponseBody> postRequiredAsync(ParameterGroupingPostRequiredParameters parameterGroupingPostRequiredParameters, final ServiceCallback<Void> serviceCallback);

    /**
     * Post a bunch of optional parameters grouped
     *
     * @param parameterGroupingPostOptionalParameters Additional parameters for the operation
     * @throws ServiceException the exception wrapped in ServiceException if failed.
     */
    void postOptional(ParameterGroupingPostOptionalParameters parameterGroupingPostOptionalParameters) throws ServiceException;

    /**
     * Post a bunch of optional parameters grouped
     *
     * @param parameterGroupingPostOptionalParameters Additional parameters for the operation
     * @param serviceCallback the async ServiceCallback to handle successful and failed responses.
     * @return the {@link Call} object
     */
    Call<ResponseBody> postOptionalAsync(ParameterGroupingPostOptionalParameters parameterGroupingPostOptionalParameters, final ServiceCallback<Void> serviceCallback);

    /**
     * Post parameters from multiple different parameter groups
     *
     * @param firstParameterGroup Additional parameters for the operation
     * @param secondParameterGroup Additional parameters for the operation
     * @throws ServiceException the exception wrapped in ServiceException if failed.
     */
    void postMultipleParameterGroups(FirstParameterGroup firstParameterGroup, SecondParameterGroup secondParameterGroup) throws ServiceException;

    /**
     * Post parameters from multiple different parameter groups
     *
     * @param firstParameterGroup Additional parameters for the operation
     * @param secondParameterGroup Additional parameters for the operation
     * @param serviceCallback the async ServiceCallback to handle successful and failed responses.
     * @return the {@link Call} object
     */
    Call<ResponseBody> postMultipleParameterGroupsAsync(FirstParameterGroup firstParameterGroup, SecondParameterGroup secondParameterGroup, final ServiceCallback<Void> serviceCallback);

}
