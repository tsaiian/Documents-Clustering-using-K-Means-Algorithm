using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextClustering.Lib;

namespace select_review_to_label.k_Means
{
    /// <summary>
    /// 整個K-means的介面
    /// </summary>
    class K_Means
    {
        private int txtClusterNum;
        private DocumentCollection docCollection;
        private List<Centroid> resultSet;
        private int totalIteration = 0;

        public K_Means()
        {
            docCollection = new DocumentCollection() { DocumentList = new List<string>() };
        }

        public K_Means(int num)
        {
            docCollection = new DocumentCollection() { DocumentList = new List<string>() };
            txtClusterNum = num;
        }

        /// <summary>
        /// 增加一篇文章進去
        /// </summary>
        /// <param name="article">一篇文章，用空格分開。</param>
        public void addDoc(string article)
        {
            docCollection.DocumentList.Add(article);
        }

        /// <summary>
        /// 開始訓練
        /// </summary>
        public void train()
        {
            List<DocumentVector> vSpace = VectorSpaceModel.ProcessDocumentCollection(docCollection);

            totalIteration = 0;
            resultSet = DocumnetClustering.PrepareDocumentCluster(txtClusterNum, vSpace, ref  totalIteration);


            Console.WriteLine("totalIteration: " + totalIteration.ToString());
        }

        /// <summary>
        /// 取得分群結果
        /// </summary>
        public List<List<string>> getResult()
        {
            if (resultSet == null)
            {
                Console.WriteLine("not train yet.");
                return null;
            }
            else
            {
                string msg = string.Empty;


                List<List<string>> result = new List<List<string>>();

                foreach (Centroid c in resultSet)
                {
                    List<string> clusterContentList = new List<string>();

                    foreach (DocumentVector document in c.GroupedDocument)
                        clusterContentList.Add(document.Content);

                    result.Add(clusterContentList);

                }
                return result;
            }
        }

        /// <summary>
        /// 直接印出分群結果
        /// </summary>
        public void showResult()
        {
            if (resultSet == null)
            {
                Console.WriteLine("not train yet.");
                return;
            }

            string msg = string.Empty;
            int count = 1;
            foreach (Centroid c in resultSet)
            {
                msg += String.Format("------------------------------[ CLUSTER {0} ]-----------------------------{1}", count, System.Environment.NewLine);
                foreach (DocumentVector document in c.GroupedDocument)
                {
                    //msg += "Doc ID: " + docIdDic.ge
                    msg += document.Content + System.Environment.NewLine;
                    if (c.GroupedDocument.Count > 1)
                        msg += String.Format("{0}--------------------------------------------------------------------------{0}", System.Environment.NewLine);
                }
                count++;
            }

            Console.WriteLine(msg);
        }

        /// <summary>
        /// 共跑了幾個Iteration
        /// </summary>
        public int getTotalIteration()
        {
            return totalIteration;
        }
        
    }
}
